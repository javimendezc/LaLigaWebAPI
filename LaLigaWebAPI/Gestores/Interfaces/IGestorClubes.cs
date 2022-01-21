using LaLigaWebAPI.Models;
using System.Collections.Generic;

namespace LaLigaWebAPI.Gestores.Interfaces
{
    public interface IGestorClubes
    {
        List<Club> GetAll(int pagina = 0, int elementos = 0);
        Club Get(int id);
        void Add(Club club);
        void Update(Club club);
        bool Check(Club club);
    }
}
