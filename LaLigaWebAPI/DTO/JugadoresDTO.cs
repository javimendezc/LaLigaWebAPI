using Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaLigaWebAPI.DTO
{
    public class JugadoresDTO
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Posicion { get; set; }

        public JugadoresDTO(Jugadores j)
        {
            id = j.id;
            Nombre = j.Nombre;
            FechaNacimiento = j.FechaNacimiento;
            Posicion = j.Posicion;
        }
    }
}