using System.Collections.Generic;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Persistence
{
    public class Repository<T> : IRepository<T>
    {
        public virtual void Save(T entity)
        {
            InstanceProvider.GetInstance<Instance.Persistence>().Save(entity);
        }

        public virtual void Update(T entity)
        {
            InstanceProvider.GetInstance<Instance.Persistence>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            InstanceProvider.GetInstance<Instance.Persistence>().Delete(entity);
        }

        public virtual IList<T> Get(T example)
        {
            return InstanceProvider.GetInstance<Instance.Persistence>().Get<T>(example);
        }

        public virtual IList<T> Get()
        {
            return InstanceProvider.GetInstance<Instance.Persistence>().Get<T>();
        }
    }
}
 