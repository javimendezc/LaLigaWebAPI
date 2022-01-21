using Conexion;
using LaLigaWebAPI.DAO.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LaLigaWebAPI.DAO
{
    public class JugadoresClubesDAO : DAO<JugadoresClubes>, IJugadoresClubesDAO
    {
        public JugadoresClubesDAO(ILaLigaEntities dbContext) : base(dbContext) { }


        public override bool Check(int id)
        {
            bool result = dbCntxt.JugadoresClubes.Count(c => c.id == id) > 0;
            return result;
        }


        private protected override List<JugadoresClubes> GetAll()
        {
            using (ILaLigaEntities dbContext = this.dbCntxt)
            {
                List<JugadoresClubes> lstOut = dbContext.JugadoresClubes.ToList();
                return lstOut;
            }
        }

        public List<JugadoresClubes> GetAll(int idClub, int pagina, int elementos)
        {
            List<JugadoresClubes> lstOut = this.GetAll().Where(c => c.idClub == idClub).ToList();
            //Si se especifica página y número de elementos, devolvemos los resultados paginados
            if ((pagina > 0) && (elementos > 0))
            {
                lstOut = lstOut.OrderBy(x => x.id).Skip((pagina - 1) * elementos).Take(elementos).ToList();
            }
            return lstOut;
        }

        public override void Add(JugadoresClubes jugadorClub)
        {
            dbCntxt.JugadoresClubes.Add(jugadorClub);
            dbCntxt.SaveChanges();
        }

        public override void Update(JugadoresClubes jugadorClub)
        {
            dbCntxt.Entry(jugadorClub).State = EntityState.Modified;
            dbCntxt.SaveChanges();
        }

        public override void Delete(int id)
        {
            var jugadorClub = dbCntxt.JugadoresClubes.Find(id);
            dbCntxt.JugadoresClubes.Remove(jugadorClub);
            dbCntxt.SaveChanges();
        }

        public bool CheckLimit(int idClub)
        {
            //Devuelve true si no hemos llegado al límite: permitirá la inserción
            return dbCntxt.JugadoresClubes.Where(x => x.idClub == idClub).Count() < Constantes.Constantes.LIMITE_JUGADORES_CLUB;
        }

        public bool CheckSalarioPresupuesto(JugadoresClubes jugadorClub)
        {
            //Devuelve true si el salario del jugador no hace superar la masa salarial del presupuesto del club
            decimal presupuestoClub = dbCntxt.Clubes.Find(jugadorClub.idClub).Presupuesto;
            decimal masaSalarial = 0;
            var lstJugadoresClub = dbCntxt.JugadoresClubes.Where(x => x.idClub == jugadorClub.idClub).ToList();
            if (lstJugadoresClub.Count > 0)
            {
                masaSalarial = lstJugadoresClub.Sum(x => x.Salario);
            }

            return (masaSalarial + jugadorClub.Salario <= presupuestoClub);
        }

        public JugadoresClubes GetInfoJugadorClub(int id)
        {
            return dbCntxt.JugadoresClubes.Find(id);
        }
    }
}