using LaLigaConsumer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LaLigaConsumer.Controllers
{
    public class ClubesController : Controller
    {
        string baseAddress = "http://localhost:53129";


        // GET: Clubes
        public async Task<ActionResult> Index(string searchString, int? page)
        {
            List<Club> clubs = new List<Club>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"api/clubes");
                if (res.IsSuccessStatusCode)
                {
                    var clubResponse = res.Content.ReadAsStringAsync().Result;
                    clubs = JsonConvert.DeserializeObject<List<Club>>(clubResponse);
                }

                //Configuración del tamaño de página y número de página por defecto
                int pageSize = 5;
                int pageNumber = (page ?? 1);

                //Búsqueda por Nombre
                if (!String.IsNullOrEmpty(searchString))
                {
                    clubs = clubs.FindAll(c => c.Nombre.ToLower().Contains(searchString.ToLower()));
                    pageNumber = (clubs.Count <= pageSize) ? 1 : pageNumber;
                }
                return View(clubs.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult create() { return View(); }

        [HttpPost]
        public ActionResult create(Club club)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = "http://localhost:53129/api/clubes";
                client.BaseAddress = new Uri(baseAddress);
                var postTask = client.PostAsJsonAsync<Club>(baseAddress, club);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error al crear el registro");
            return View(club);
        }

        public ActionResult Edit(int id)
        {
            Club club = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //http get
                var responseTask = client.GetAsync($"api/clubes/{id.ToString()}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Club>();
                    readTask.Wait();
                    club = readTask.Result;
                }
            }
            return View(club);
        }

        [HttpPost]
        public ActionResult Edit(Club club)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //http post
                var putTask = client.PutAsJsonAsync<Club>($"api/clubes/{club.Id}", club);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(club);
        }

        public async Task<ActionResult> Detail(int id, string searchString, int? page)
        {
            List<JugadoresClub> jugadores = new List<JugadoresClub>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"api/fichas/{id.ToString()}");
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    jugadores = JsonConvert.DeserializeObject<List<JugadoresClub>>(response);
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);

                //Búsqueda por Nombre o Posición
                if (!String.IsNullOrEmpty(searchString))
                {
                    jugadores = jugadores.FindAll(c => c.jugador.Nombre.ToLower().Contains(searchString.ToLower()) ||
                                                        c.jugador.Posicion.ToLower().Contains(searchString.ToLower()));
                    pageNumber = (jugadores.Count <= pageSize) ? 1 : pageNumber;
                }

                var viewModel = new ViewModelDetail() { IdClub = id, jugadoresClub = jugadores.ToPagedList(pageNumber, pageSize) };

                return View(viewModel);
            }
        }

        private List<SelectListItem> cargarComboJugadoresLibres()
        {
            var listOut = new List<SelectListItem>();
            //Sacamos los jugadores libres para cargar en el combo
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //http get
                var responseTask = client.GetAsync($"api/jugadoreslibres/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Jugador>>();
                    readTask.Wait();
                    List<Jugador> jugadores = readTask.Result;

                    List<SelectListItem> list = new List<SelectListItem>();
                    foreach (var jugadorLibre in jugadores)
                    {
                        list.Add(new SelectListItem() { Text = jugadorLibre.Nombre, Value = jugadorLibre.Id.ToString() });
                    }
                    listOut = list;
                }
            }
            return listOut;
        }

        public ActionResult Fichar(int id)
        {
            //Sacamos los jugadores libres para cargar en el combo
            ViewBag.JugadoresLibres = this.cargarComboJugadoresLibres();

            var modelJugadorClub = new JugadoresClub() { club = new Club() { Id = id } };
            return View(modelJugadorClub);
        }

        [HttpPost]
        public ActionResult Fichar(JugadoresClub jugadorClub)
        {
            var strErrorMsg = string.Empty;

            using (var client = new HttpClient())
            {
                var baseAddress = "http://localhost:53129/api/fichas";
                client.BaseAddress = new Uri(baseAddress);
                var postTask = client.PostAsJsonAsync<JugadoresClub>(baseAddress, jugadorClub);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Capturamos el mensaje de error de la respuesta a través del result.Content y deserializando el JSON
                    strErrorMsg = ((JProperty)((JContainer)JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result)).First).Value.ToString();
                }
            }
            ModelState.AddModelError(string.Empty, $"Error al crear el registro: {strErrorMsg}");

            //Recargamos el combo de jugadores libres
            ViewBag.JugadoresLibres = this.cargarComboJugadoresLibres();
            return View(jugadorClub);
        }

        public ActionResult Delete(int id)
        {
            JugadoresClub jugadorClub = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //http get
                var responseTask = client.GetAsync($"api/infojugadorclub/{id.ToString()}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<JugadoresClub>();
                    readTask.Wait();   
                    jugadorClub = readTask.Result;
                }
            }

            return View(jugadorClub);
        }

        [HttpPost]
        public ActionResult Delete(JugadoresClub jugadorClub, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //Http delete
                var deleteTask = client.DeleteAsync($"api/fichas/{id.ToString()}");
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(jugadorClub);
        }
    }
}