using Conexion;
using LaLigaWebAPI.DAO.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LaLigaWebAPI.DAO
{
    public class JugadoresDAO : DAO<Jugadores>, IJugadoresDAO
    {
        public JugadoresDAO(ILaLigaEntities dbContext) : base(dbContext) { }


        public override bool Check(int id)
        {
            bool result = dbCntxt.Jugadores.Count(c => c.id == id) > 0;
            return result;
        }


        private protected override List<Jugadores> GetAll()
        {
            using (ILaLigaEntities dbContext = this.dbCntxt)
            {
                List<Jugadores> lstOut = dbContext.Jugadores.ToList();
                return lstOut;
            }

        }

        public List<Jugadores> GetAll(int pagina, int elementos)
        {
            List<Jugadores> lstOut = this.GetAll();

            //Si se especifica página y número de elementos, devolvemos los resultados paginados
            if ((pagina > 0) && (elementos > 0))
            {
                lstOut = lstOut.OrderBy(x => x.id).Skip((pagina - 1) * elementos).Take(elementos).ToList();
            }
            return lstOut;
        }

        public List<Jugadores> GetLibres()
        {
            //Devuelve los jugadores cuyo Id no estén incluidos en la tabla de JugadoresClubes (son jugadores libres)
            var lst = dbCntxt.Jugadores.Where(x => !dbCntxt.JugadoresClubes.Select(jc => jc.idJugador).Contains(x.id)).ToList();
            return lst;
        }

        public Jugadores GetJugador(int id)
        {
            return dbCntxt.Jugadores.Find(id);
        }

        public override void Add(Jugadores jugador)
        {
            dbCntxt.Jugadores.Add(jugador);
            dbCntxt.SaveChanges();
        }

        public override void Update(Jugadores jugador)
        {
            dbCntxt.Entry(jugador).State = EntityState.Modified;
            dbCntxt.SaveChanges();
        }

        public override void Delete(int id)
        {
            var jugador = dbCntxt.Jugadores.Find(id);
            dbCntxt.Jugadores.Remove(jugador);
            dbCntxt.SaveChanges();
        }
    }
}