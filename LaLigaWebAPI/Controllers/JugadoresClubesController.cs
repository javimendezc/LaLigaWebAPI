using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LaLigaWebAPI.Controllers
{
    public class JugadoresClubesController : ApiController
    {
        private IGestorJugadoresClubes gestorJugadoresClubes;

        public JugadoresClubesController(IGestorJugadoresClubes gestorJugadoresClubes)
        {
            this.gestorJugadoresClubes = gestorJugadoresClubes;
        }

        [HttpGet]
        public IEnumerable<JugadorClub> GetJugadores(int id, int pagina = 0, int elementos = 0)
        {
            return gestorJugadoresClubes.GetAll(id, pagina, elementos);
        }

        [HttpPost]
        public IHttpActionResult AddJugador([FromBody] JugadorClub jugador)
        {
            bool badRequest = false;
            string badRequestMsg = string.Empty;

            if (!ModelState.IsValid)
            {
                badRequest = true;
                badRequestMsg = "Datos inválidos";
            }
            else if (!gestorJugadoresClubes.CheckLimit(jugador.club.Id))
            {
                badRequest = true;
                badRequestMsg = "Se ha llegado al límite de jugadores en el club";
            }
            else if (!gestorJugadoresClubes.CheckSalarioPresupuesto(jugador))
            {
                badRequest = true;
                badRequestMsg = "El salario del jugador supera la masa salarial permitida para el club";
            }

            if (!badRequest)
            {
                gestorJugadoresClubes.Add(jugador);

                return Ok();
            }
            else { return BadRequest(badRequestMsg); }
        }

        [HttpDelete]
        public IHttpActionResult DeleteJugador(int id)
        {
            if (gestorJugadoresClubes.Check(id))
            {
                gestorJugadoresClubes.Delete(id);

                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
