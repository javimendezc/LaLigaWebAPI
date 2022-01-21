using Conexion;
using System.Collections.Generic;

namespace LaLigaWebAPI.DAO.Interfaces
{
    public interface IClubesDAO
    {
        bool Check(int id);
        List<Clubes> GetAll(int pagina, int elementos);
        Clubes Get(int id);
        void Add(Clubes club);
        void Update(Clubes club);
        void Delete(int id);
    }
}
