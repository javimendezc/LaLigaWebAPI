using Conexion;
using LaLigaWebAPI.DAO.Interfaces;
using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LaLigaWebAPI.Gestores
{
    public class GestorClubes : IGestorClubes
    {
        private IClubesDAO clubesDAO;

        //Coge la instancia del contenedor de IoC de Unity
        public GestorClubes(IClubesDAO clubesDAO)
        {
            this.clubesDAO = clubesDAO;
        }

        public List<Club> GetAll(int pagina = 0, int elementos = 0)
        {
            return (from Clubes c in clubesDAO.GetAll(pagina, elementos)
                    select new Club
                    {
                        Id = c.id,
                        Nombre = c.Nombre,
                        Presupuesto = c.Presupuesto
                    }).ToList();
        }

        public Club Get(int id)
        {
            var club = clubesDAO.Get(id);
            return new Club { Id = club.id, Nombre = club.Nombre, Presupuesto = club.Presupuesto };
        }

        public void Add(Club club)
        {
            Clubes entity = new Clubes() { Nombre = club.Nombre, Presupuesto = club.Presupuesto };
            clubesDAO.Add(entity);
        }

        public void Update(Club club)
        {
            var entity = new Clubes() { id = club.Id, Nombre = club.Nombre, Presupuesto = club.Presupuesto };
            clubesDAO.Update(entity);
        }

        public bool Check(Club club)
        {
            return clubesDAO.Check(club.Id);
        }
    }
}