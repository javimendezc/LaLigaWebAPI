using Conexion;
using System.Collections.Generic;

namespace LaLigaWebAPI.DAO.Interfaces
{
    public interface IJugadoresClubesDAO
    {
        List<JugadoresClubes> GetAll(int idClub, int pagina, int elementos);
        JugadoresClubes GetInfoJugadorClub(int id);
        void Add(JugadoresClubes jugadorClub);
        void Update(JugadoresClubes jugadorClub);
        void Delete(int id);
        bool Check(int id);
        bool CheckLimit(int idClub);
        bool CheckSalarioPresupuesto(JugadoresClubes jugadorClub);
    }
}
