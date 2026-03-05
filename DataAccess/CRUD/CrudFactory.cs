using System.Collections.Generic;
using DataAccess.DAO;

namespace DataAccess.CRUD
{
    public abstract class CrudFactory
    {
        protected SQLDAO dao;

        public CrudFactory()
        {
            dao = SQLDAO.GetInstance();
        }

        public abstract void Create(object dto);
        public abstract void Update(object dto);
        public abstract void Delete(int id);
        public abstract List<T> RetrieveAll<T>();
        public abstract T RetrieveById<T>(int id);
    }
}
