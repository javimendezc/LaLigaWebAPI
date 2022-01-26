using System;

namespace LaLigaWebAPI.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Posicion { get; set; }
    }
}