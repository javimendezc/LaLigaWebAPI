namespace LaLigaConsumer.Models
{
    public class ViewModelDetail
    {
        public int IdClub { get; set; }
        public PagedList.IPagedList<LaLigaConsumer.Models.JugadoresClub> jugadoresClub { get; set; }
    }
}