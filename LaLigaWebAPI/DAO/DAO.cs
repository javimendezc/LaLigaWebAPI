using Conexion;
using System.Collections.Generic;

namespace LaLigaWebAPI.DAO
{
    public abstract class DAO<T>
    {
        protected ILaLigaEntities dbCntxt;

        //Coge la instancia del contenedor de IoC de Unity
        public DAO(ILaLigaEntities dbContext)
        {
            this.dbCntxt = dbContext;
        }

        public abstract bool Check(int id);

        public abstract void Add(T t);
        public abstract void Update(T t);
        public abstract void Delete(int id);

        private protected abstract List<T> GetAll();
    }
}