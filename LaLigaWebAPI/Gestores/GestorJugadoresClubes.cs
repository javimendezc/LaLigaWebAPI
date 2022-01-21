using Conexion;
using LaLigaWebAPI.DAO.Interfaces;
using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Collections.Generic;

namespace LaLigaWebAPI.Gestores
{
    public class GestorJugadoresClubes : IGestorJugadoresClubes
    {
        private IJugadoresClubesDAO jugadoresClubesDAO;
        private IJugadoresDAO jugadoresDAO;
        private IClubesDAO clubesDAO;

        //Coge la instancia del contenedor de IoC de Unity
        public GestorJugadoresClubes(IJugadoresClubesDAO jugadoresClubesDAO, IJugadoresDAO jugadoresDAO, IClubesDAO clubesDAO)
        {
            this.jugadoresClubesDAO = jugadoresClubesDAO;
            this.jugadoresDAO = jugadoresDAO;
            this.clubesDAO = clubesDAO;
        }


        public List<JugadorClub> GetAll(int idClub, int pagina = 0, int elementos = 0)
        {
            List<JugadoresClubes> jugadoresClubes = jugadoresClubesDAO.GetAll(idClub, pagina, elementos);
            List<JugadorClub> jugadoresClub = new List<JugadorClub>();
            foreach (JugadoresClubes j in jugadoresClubes)
            {
                Jugadores jugadorInfo = jugadoresDAO.GetJugador(j.idJugador);
                Clubes clubInfo = clubesDAO.Get(j.idClub);
                JugadorClub jugador = new JugadorClub()
                {
                    Id = j.id,
                    club = new Club() { Id = j.idClub, Nombre = clubInfo.Nombre, Presupuesto = clubInfo.Presupuesto },
                    jugador = new Jugador() { Id = j.idJugador, Nombre = jugadorInfo.Nombre, FechaNacimiento = jugadorInfo.FechaNacimiento, Posicion = jugadorInfo.Posicion },
                    salario = j.Salario
                };
                jugadoresClub.Add(jugador);
            }
            return jugadoresClub;
        }

        public void Add(JugadorClub jugadorClub)
        {
            JugadoresClubes entity = new JugadoresClubes() { idClub = jugadorClub.club.Id, idJugador = jugadorClub.jugador.Id, Salario = jugadorClub.salario };
            jugadoresClubesDAO.Add(entity);
        }

        public void Delete(int id)
        {
            jugadoresClubesDAO.Delete(id);
        }

        public bool Check(int id)
        {
            return jugadoresClubesDAO.Check(id);
        }

        public bool CheckLimit(int idClub)
        {
            //Devolverá True si no hemos llegado al límite de 5 jugadores: permitirá la inserción
            return jugadoresClubesDAO.CheckLimit(idClub);
        }

        public bool CheckSalarioPresupuesto(JugadorClub jugadorClub)
        {
            JugadoresClubes jugador = new JugadoresClubes() { idClub = jugadorClub.club.Id, Salario = jugadorClub.salario };
            return jugadoresClubesDAO.CheckSalarioPresupuesto(jugador);
        }

        public JugadorClub GetInfoJugadorClub(int id)
        {
            var entity = jugadoresClubesDAO.GetInfoJugadorClub(id);

            Jugadores jugadorInfo = jugadoresDAO.GetJugador(entity.idJugador);
            Clubes clubInfo = clubesDAO.Get(entity.idClub);

            JugadorClub jugadorClub = new JugadorClub()
            {
                Id = id,
                club = new Club() { Id = entity.idClub, Nombre = clubInfo.Nombre, Presupuesto = clubInfo.Presupuesto },
                jugador = new Jugador() { Id = entity.idJugador, Nombre = jugadorInfo.Nombre, FechaNacimiento = jugadorInfo.FechaNacimiento, Posicion = jugadorInfo.Posicion },
                salario = entity.Salario
            };
            return jugadorClub;
        }
    }
}