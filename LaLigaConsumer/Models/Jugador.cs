using System;
using System.ComponentModel.DataAnnotations;

namespace LaLigaConsumer.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public string Posicion { get; set; }
    }
}