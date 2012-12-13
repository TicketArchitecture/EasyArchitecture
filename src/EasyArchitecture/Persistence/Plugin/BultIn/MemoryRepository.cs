using System.Collections.Generic;
using EasyArchitecture.Persistence.Plugin.Contracts;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    public class MemoryRepository<T> : Repository<T> where T : class
    {
        //TODO: method name conflict
        private Session GetLocalSession()
        {
            return (Session) base.GetSession();
        }

        public  void Save(T obj)
        {
            GetLocalSession().Save(obj);
        }

        public  void Update(T obj)
        {
            GetLocalSession().Update(obj);
        }

        public  void Delete(T obj)
        {
            GetLocalSession().Delete(obj);
        }

        public  T Get(object key)
        {
            return GetLocalSession().Get<T>(key);
        }

        public  IList<T> Get()
        {
            return GetLocalSession().Get<T>();
        }
    }
}
 