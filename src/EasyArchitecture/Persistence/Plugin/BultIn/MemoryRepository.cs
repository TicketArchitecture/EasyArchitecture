using System.Collections.Generic;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    public class MemoryRepository<T> : IRepository<T> where T : class
    {
        private static Session GetLocalSession()
        {
            return (Session) InstanceProvider.GetInstance<Instance.Persistence>().GetSession();
            //return (Session) ConfigurationSelector.Selector().Persistence.GetSession();
        }

        public void Save(T entity)
        {
            GetLocalSession().Save(entity);
        }

        public void Update(T entity)
        {
            GetLocalSession().Update(entity);
        }

        public  void Delete(T entity)
        {
            GetLocalSession().Delete(entity);
        }

        public IList<T> Get(object specification)
        {
            return GetLocalSession().Get<T>();
        }
    }
}
 