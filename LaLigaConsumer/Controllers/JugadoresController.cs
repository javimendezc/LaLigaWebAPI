using LaLigaConsumer.Models;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LaLigaConsumer.Controllers
{
    public class JugadoresController : Controller
    {
        string baseAddress = "http://localhost:53129";

        // GET: Jugadores
        public async Task<ActionResult> Index(string searchString, int? page)
        {
            List<Jugador> jugadores = new List<Jugador>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/jugadores");
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    jugadores = JsonConvert.DeserializeObject<List<Jugador>>(response);
                }

                //Configuración del tamaño de página y número de página por defecto
                int pageSize = 5;
                int pageNumber = (page ?? 1);

                //Búsqueda por Nombre o Posición
                if (!String.IsNullOrEmpty(searchString))
                {
                    jugadores = jugadores.FindAll(c => c.Nombre.ToLower().Contains(searchString.ToLower()) ||
                                                        c.Posicion.ToLower().Contains(searchString.ToLower()));
                    pageNumber = (jugadores.Count <= pageSize) ? 1 : pageNumber;
                }
                return View(jugadores.ToPagedList(pageNumber, pageSize));
            }
        }


        public ActionResult create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Portero", Value = "Portero" });
            list.Add(new SelectListItem() { Text = "Defensa", Value = "Defensa" });
            list.Add(new SelectListItem() { Text = "Centrocampista", Value = "Centrocampista" });
            list.Add(new SelectListItem() { Text = "Delantero", Value = "Delantero" });
            ViewBag.Posiciones = list;

            return View();
        }

        [HttpPost]
        public ActionResult create(Jugador jugador)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = "http://localhost:53129/api/jugadores";
                client.BaseAddress = new Uri(baseAddress);
                var postTask = client.PostAsJsonAsync<Jugador>(baseAddress, jugador);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error al crear el registro");
            return View(jugador);
        }
    }
}