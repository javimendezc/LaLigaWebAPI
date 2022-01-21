using System;
using System.ComponentModel.DataAnnotations;

namespace LaLigaConsumer.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public string Posicion { get; set; }
    }
}