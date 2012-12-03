using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using EasyArchitecture.Common.Persistence;

namespace EasyArchitecture.Plugins.EntityFramework
{

    public class EntityRepository<T> : Repository<T> where T : class
    {
        public virtual void Save(T obj)
        {
            GetLocalSession().Set<T>().Add(obj);
        }

        public virtual void Update(T obj)
        {
            GetLocalSession().Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(T obj)
        {
            GetLocalSession().Set<T>().Remove(obj);
        }

        public virtual T Get(object key)
        {
            return GetLocalSession().Set<T>().Find(key);
        }

        public virtual IList<T> Get()
        {
            return GetLocalSession().Set<T>().ToList();
        }

        private DbContext GetLocalSession()
        {
            return (DbContext)base.GetSession();
        }

        protected IQueryable<T> CreateCriteria()
        {
            return GetLocalSession().Set<T>().AsQueryable();
        }
    }
}

