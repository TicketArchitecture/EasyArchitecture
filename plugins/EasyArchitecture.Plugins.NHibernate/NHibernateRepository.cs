using System.Collections.Generic;
using EasyArchitecture.Common.Persistence;
using NHibernate;

namespace EasyArchitecture.Plugins.NHibernate
{
    public abstract class NHibernateRepository<T>:Repository<T> where T : class
    {
        //TODO: method name conflict
        private ISession GetLocalSession()
        {
            return (ISession)base.GetSession();
        }

        protected ICriteria CreateCriteria()
        {
            
            return GetLocalSession().CreateCriteria<T>();
        }

        public virtual void Save(T obj)
        {
            GetLocalSession().Save(obj);
        }

        public virtual void Update(T obj)
        {
            GetLocalSession().Update(obj);
            GetLocalSession().Flush();
        }

        public virtual void Delete(T obj)
        {
            GetLocalSession().Delete(GetLocalSession().Merge(obj));
            GetLocalSession().Flush();
        }

        public virtual T Get(object key)
        {
            return GetLocalSession().Get<T>(key);
        }

        public virtual IList<T> Get()
        {
            return GetLocalSession().CreateCriteria(typeof(T)).List<T>();
        }
    }
}

