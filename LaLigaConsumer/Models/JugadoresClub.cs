using System.ComponentModel.DataAnnotations;

namespace LaLigaConsumer.Models
{
    public class JugadoresClub
    {
        public int Id { get; set; }
        public Club club { get; set; }
        public Jugador jugador { get; set; }
        [Required]
        public decimal salario { get; set; }

        public JugadoresClub()
        {
            club = new Club();
            jugador = new Jugador();
        }
    }
}