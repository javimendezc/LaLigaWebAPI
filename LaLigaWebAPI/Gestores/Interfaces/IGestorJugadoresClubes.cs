using LaLigaWebAPI.Models;
using System.Collections.Generic;

namespace LaLigaWebAPI.Gestores.Interfaces
{
    public interface IGestorJugadoresClubes
    {
        List<JugadorClub> GetAll(int idClub, int pagina = 0, int elementos = 0);
        JugadorClub GetInfoJugadorClub(int id);
        void Add(JugadorClub jugadorClub);
        void Delete(int id);
        bool Check(int id);
        bool CheckLimit(int idClub);
        bool CheckSalarioPresupuesto(JugadorClub jugadorClub);
    }
}