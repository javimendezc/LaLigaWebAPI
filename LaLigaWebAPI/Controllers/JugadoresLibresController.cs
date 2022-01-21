using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LaLigaWebAPI.Controllers
{
    public class JugadoresLibresController : ApiController
    {
        private IGestorJugadores gestorJugadores;

        //Coge la instancia del contenedor de IoC de Unity
        public JugadoresLibresController(IGestorJugadores gestorJugadores)
        {
            this.gestorJugadores = gestorJugadores;
        }

        [HttpGet]
        public IEnumerable<Jugador> GetJugadores()
        {
            return gestorJugadores.GetFree();
        }
    }
}
