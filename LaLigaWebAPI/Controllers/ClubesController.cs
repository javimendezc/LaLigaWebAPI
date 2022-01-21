using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LaLigaWebAPI.Controllers
{
    public class ClubesController : ApiController
    {
        private IGestorClubes gestorClubes;

        //Coge la instancia del contenedor de IoC de Unity
        public ClubesController(IGestorClubes gestorClubes)
        {
            this.gestorClubes = gestorClubes;
        }


        [HttpGet]
        public IEnumerable<Club> GetClubes(int pagina = 0, int elementos = 0)
        {
            return gestorClubes.GetAll(pagina, elementos);
        }

        [HttpGet]
        public Club Get(int id)
        {
            return gestorClubes.Get(id);
        }

        [HttpPost]
        public IHttpActionResult AddClub([FromBody] Club club)
        {
            if (ModelState.IsValid)
            {
                gestorClubes.Add(club);

                return Ok();
            }
            else { return BadRequest(); }
        }

        [HttpPut]
        public IHttpActionResult UpdateClub([FromBody] Club club)
        {
            if (ModelState.IsValid)
            {
                var clubExiste = gestorClubes.Check(club);
                if (clubExiste)
                {
                    gestorClubes.Update(club);

                    return Ok();
                }
                else { return NotFound(); }
            }
            else { return BadRequest(); }
        }
    }
}
