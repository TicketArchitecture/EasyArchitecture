using System.Collections.Generic;
using EasyArchitecture.Persistence.Plugin.BultIn;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Persistence
{
    public class Repository<T> : IRepository<T>
    {
        private static Session GetSession()
        {
            return (Session) InstanceProvider.GetInstance<Instance.Persistence>().GetSession();
        }

        public virtual void Save(T entity)
        {
            GetSession().Save(entity);
        }

        public virtual void Update(T entity)
        {
            GetSession().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            GetSession().Delete(entity);
        }

        public virtual IList<T> Get(T qbe)
        {
            return GetSession().Get<T>(qbe);
        }

        public virtual IList<T> Get()
        {
            return GetSession().Get<T>();
        }
    }
}
 