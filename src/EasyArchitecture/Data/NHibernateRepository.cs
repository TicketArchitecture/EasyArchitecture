using System.Collections.Generic;
using EasyArchitecture.Diagnostic;
using NHibernate;

namespace EasyArchitecture.Data
{
    public abstract class NHibernateRepository<T> where T : class
    {
        protected ICriteria CreateCriteria()
        {
            //Log.Debug(this, "CreateCriteria");
            return PersistenceManager.GetSession().CreateCriteria<T>();
        }

        public virtual void Save(T obj)
        {
            //Log.Debug(this, obj);
            PersistenceManager.GetSession().Save(obj);
        }

        public virtual void Update(T obj)
        {
            //Log.Debug(this, obj);
            PersistenceManager.GetSession().Update(obj);
            PersistenceManager.GetSession().Flush();
        }

        public virtual void Delete(T obj)
        {
            //Log.Debug(this, obj);
            PersistenceManager.GetSession().Delete(PersistenceManager.GetSession().Merge(obj));
            PersistenceManager.GetSession().Flush();
        }

        public virtual T Get(object key)
        {
            //Log.Debug(this, key);
            return PersistenceManager.GetSession().Get<T>(key);
        }


        public virtual IList<T> Get()
        {
            return PersistenceManager.GetSession().CreateCriteria(typeof(T)).List<T>();
        }
    }
}

