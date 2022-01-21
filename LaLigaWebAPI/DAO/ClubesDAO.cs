using Conexion;
using LaLigaWebAPI.DAO.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LaLigaWebAPI.DAO
{
    public class ClubesDAO : DAO<Clubes>, IClubesDAO
    {
        public ClubesDAO(ILaLigaEntities dbContext) : base(dbContext) { }


        public override bool Check(int id)
        {
            bool result = dbCntxt.Clubes.Count(c => c.id == id) > 0;
            return result;
        }


        private protected override List<Clubes> GetAll()
        {
            using (ILaLigaEntities dbContext = this.dbCntxt)
            {
                List<Clubes> lstOut = dbContext.Clubes.ToList();
                return lstOut;
            }
        }

        public List<Clubes> GetAll(int pagina, int elementos)
        {
            List<Clubes> lstOut = this.GetAll();
            //Si se especifica página y número de elementos, devolvemos los resultados paginados
            if ((pagina > 0) && (elementos > 0))
            {
                lstOut = lstOut.OrderBy(x => x.id).Skip((pagina - 1) * elementos).Take(elementos).ToList();
            }
            return lstOut;
        }

        public Clubes Get(int id)
        {
            return dbCntxt.Clubes.Find(id);
        }

        public override void Add(Clubes club)
        {
            dbCntxt.Clubes.Add(club);
            dbCntxt.SaveChanges();
        }

        public override void Update(Clubes club)
        {
            dbCntxt.Entry(club).State = EntityState.Modified;
            dbCntxt.SaveChanges();
        }

        public override void Delete(int id)
        {
            var club = dbCntxt.Clubes.Find(id);
            dbCntxt.Clubes.Remove(club);
            dbCntxt.SaveChanges();
        }
    }
}