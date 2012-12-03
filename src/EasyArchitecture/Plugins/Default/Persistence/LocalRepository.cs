using System.Collections.Generic;
using EasyArchitecture.Common.Persistence;

namespace EasyArchitecture.Plugins.Default.Persistence
{
    public class LocalRepository<T> : Repository<T> where T : class
    {
        private IList<T> entities = new List<T>();

        //TODO: method name conflict
        private Session GetLocalSession()
        {
            return (Session)base.GetSession();
        }

        //protected ICriteria CreateCriteria()
        //{

        //    return GetLocalSession().CreateCriteria<T>();
        //}

        public virtual void Save(T obj)
        {
            GetLocalSession().Save(obj);
        }

        public virtual void Update(T obj)
        {
            GetLocalSession().Update(obj);
        }

        public virtual void Delete(T obj)
        {
            GetLocalSession().Delete(obj);
        }

        public virtual T Get(object key)
        {
            return GetLocalSession().Get<T>(key);
        }

        public virtual IList<T> Get()
        {
            return GetLocalSession().CreateCriteria<T>();
        }
    }
}
