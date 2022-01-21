using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Web.Http;

namespace LaLigaWebAPI.Controllers
{
    public class InfoJugadorClubController : ApiController
    {
        private IGestorJugadoresClubes gestorJugadoresClubes;

        public InfoJugadorClubController(IGestorJugadoresClubes gestorJugadoresClubes)
        {
            this.gestorJugadoresClubes = gestorJugadoresClubes;
        }

        [HttpGet]
        public JugadorClub GetInfoJugadorClub(int id)
        {
            return gestorJugadoresClubes.GetInfoJugadorClub(id);
        }
    }
}
