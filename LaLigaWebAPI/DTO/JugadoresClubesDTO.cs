using Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaLigaWebAPI.DTO
{
    public class JugadoresClubesDTO
    {
        public int id { get; set; }
        public int idClub { get; set; }
        public int idJugador { get; set; }
        public decimal Salario { get; set; }

        public virtual ClubesDTO Club { get; set; }
        public virtual JugadoresDTO Jugador { get; set; }

        public JugadoresClubesDTO (JugadoresClubes jc)
        {
            id = jc.id;
            idClub = jc.idClub;
            idJugador = jc.idJugador;
            Salario = jc.Salario;
            Club = new ClubesDTO(jc.Club);
            Jugador = new JugadoresDTO(jc.Jugador);
        }

        public JugadoresClubes ToEntity()
        {
            JugadoresClubes jc = new JugadoresClubes() { 
                id = this.id, 
                idClub = this.idClub, 
                idJugador = this.idJugador, 
                Club = new Clubes()
                {
                    id = this.Club.id,
                    Nombre = this.Club.Nombre, 
                    Presupuesto = this.Club.Presupuesto
                },
                Jugador= new Jugadores()
                {
                    id = this.Jugador.id,
                    Nombre = this.Jugador.Nombre,
                    FechaNacimiento = this.Jugador.FechaNacimiento,
                    Posicion = this.Jugador.Posicion
                }
            };
            return jc;
        }
    }
}