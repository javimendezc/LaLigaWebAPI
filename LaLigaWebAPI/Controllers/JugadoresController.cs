using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LaLigaWebAPI.Controllers
{
    public class JugadoresController : ApiController
    {
        private IGestorJugadores gestorJugadores;

        //Coge la instancia del contenedor de IoC de Unity
        public JugadoresController(IGestorJugadores gestorJugadores)
        {
            this.gestorJugadores = gestorJugadores;
        }


        [HttpGet]
        public IEnumerable<Jugador> GetJugadores(int pagina = 0, int elementos = 0)
        {
            return gestorJugadores.GetAll(pagina, elementos);
        }

        [HttpPost]
        public IHttpActionResult AddJugador([FromBody] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                gestorJugadores.Add(jugador);

                return Ok();
            }
            else { return BadRequest(); }
        }

        [HttpPut]
        public IHttpActionResult UpdateJugador([FromBody] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                var jugadorExiste = gestorJugadores.Check(jugador);
                if (jugadorExiste)
                {
                    gestorJugadores.Update(jugador);

                    return Ok();
                }
                else { return NotFound(); }
            }
            else { return BadRequest(); }
        }
    }
}
