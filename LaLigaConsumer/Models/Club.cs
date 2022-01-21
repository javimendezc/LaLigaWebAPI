using System.ComponentModel.DataAnnotations;

namespace LaLigaConsumer.Models
{
    public class Club
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.###}", ApplyFormatInEditMode = true)]
        public decimal Presupuesto { get; set; }
    }
}