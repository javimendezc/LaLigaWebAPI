using LaLigaWebAPI.Models;
using System.Collections.Generic;

namespace LaLigaWebAPI.Gestores.Interfaces
{
    public interface IGestorJugadores
    {
        List<Jugador> GetAll(int pagina = 0, int elementos = 0);
        List<Jugador> GetFree();
        void Add(Jugador jugador);
        void Update(Jugador jugador);
        bool Check(Jugador jugador);
    }
}