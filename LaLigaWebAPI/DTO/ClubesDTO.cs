using Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaLigaWebAPI.DTO
{
    public class ClubesDTO
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal Presupuesto { get; set; }

        public ClubesDTO(Clubes c)
        {
            id = c.id;
            Nombre = c.Nombre;
            Presupuesto = c.Presupuesto;
        }
    }
}