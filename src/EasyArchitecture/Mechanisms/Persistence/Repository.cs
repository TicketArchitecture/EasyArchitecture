using System.Collections.Generic;
using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Persistence
{
    public class Repository<T> : IRepository<T>
    {
        public virtual void Save(T entity)
        {
            InstanceProvider.GetInstance<Instances.Persistence.Persistence>().Save(entity);
        }

        public virtual void Update(T entity)
        {
            InstanceProvider.GetInstance<Instances.Persistence.Persistence>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            InstanceProvider.GetInstance<Instances.Persistence.Persistence>().Delete(entity);
        }

        public virtual IList<T> Get(T example)
        {
            return InstanceProvider.GetInstance<Instances.Persistence.Persistence>().Get<T>(example);
        }

        public virtual IList<T> Get()
        {
            return InstanceProvider.GetInstance<Instances.Persistence.Persistence>().Get<T>();
        }

        protected object GetUnderlayerPersistence()
        {
            return InstanceProvider.GetInstance<Instances.Persistence.Persistence>().GetUnderlayerPersistenceObject();
        }
    }
}
 