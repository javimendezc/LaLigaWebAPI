using Conexion;
using System.Collections.Generic;

namespace LaLigaWebAPI.DAO.Interfaces
{
    public interface IJugadoresDAO
    {
        bool Check(int id);
        List<Jugadores> GetAll(int pagina, int elementos);
        List<Jugadores> GetLibres();
        Jugadores GetJugador(int id);
        void Add(Jugadores club);
        void Update(Jugadores club);
        void Delete(int id);
    }
}
