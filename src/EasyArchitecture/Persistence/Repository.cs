using System.Collections.Generic;
using EasyArchitecture.Persistence.Plugin.BultIn;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Persistence
{
    public class Repository<T> : IRepository<T>
    {
        private static Session GetSession()
        {
            return (Session) InstanceProvider.GetInstance<Instance.Persistence>().GetSession();
        }

        public void Save(T entity)
        {
            GetSession().Save(entity);
        }

        public void Update(T entity)
        {
            GetSession().Update(entity);
        }

        public  void Delete(T entity)
        {
            GetSession().Delete(entity);
        }

        public IList<T> Get(T qbe)
        {
            return GetSession().Get<T>(qbe);
        }

        public IList<T> Get()
        {
            return GetSession().Get<T>();
        }

    }
}
 