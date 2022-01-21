namespace LaLigaWebAPI.Models
{
    public class JugadorClub
    {
        public int Id { get; set; }
        public Club club { get; set; }
        public Jugador jugador { get; set; }
        public decimal salario { get; set; }
    }
}