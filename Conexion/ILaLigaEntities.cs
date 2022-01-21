using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Conexion
{
    public interface ILaLigaEntities : IDisposable
    {
        DbSet<Clubes> Clubes { get; set; }
        DbSet<Jugadores> Jugadores { get; set; }
        DbSet<JugadoresClubes> JugadoresClubes { get; set; }

        DbEntityEntry Entry(object o);
        int SaveChanges();
    }
}
