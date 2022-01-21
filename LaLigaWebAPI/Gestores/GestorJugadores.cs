using Conexion;
using LaLigaWebAPI.DAO.Interfaces;
using LaLigaWebAPI.Gestores.Interfaces;
using LaLigaWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LaLigaWebAPI.Gestores
{
    public class GestorJugadores : IGestorJugadores
    {
        private IJugadoresDAO jugadoresDAO;

        //Coge la instancia del contenedor de IoC de Unity
        public GestorJugadores(IJugadoresDAO jugadoresDAO)
        {
            this.jugadoresDAO = jugadoresDAO;
        }

        public List<Jugador> GetAll(int pagina = 0, int elementos = 0)
        {
            return (from Jugadores c in jugadoresDAO.GetAll(pagina, elementos)
                    select new Jugador
                    {
                        Id = c.id,
                        Nombre = c.Nombre,
                        FechaNacimiento = c.FechaNacimiento,
                        Posicion = c.Posicion
                    }).ToList();
        }

        public List<Jugador> GetFree()
        {
            return (from Jugadores c in jugadoresDAO.GetLibres()
                    select new Jugador
                    {
                        Id = c.id,
                        Nombre = c.Nombre,
                        FechaNacimiento = c.FechaNacimiento,
                        Posicion = c.Posicion
                    }).ToList();
        }

        public void Add(Jugador jugador)
        {
            Jugadores entity = new Jugadores() { Nombre = jugador.Nombre, FechaNacimiento = jugador.FechaNacimiento, Posicion = jugador.Posicion };
            jugadoresDAO.Add(entity);
        }

        public void Update(Jugador jugador)
        {
            Jugadores entity = new Jugadores() { id = jugador.Id, Nombre = jugador.Nombre, FechaNacimiento = jugador.FechaNacimiento, Posicion = jugador.Posicion };
            jugadoresDAO.Update(entity);
        }

        public bool Check(Jugador jugador)
        {
            return jugadoresDAO.Check(jugador.Id);
        }
    }
}