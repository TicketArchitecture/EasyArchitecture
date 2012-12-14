using System.Collections.Generic;

namespace EasyArchitecture.Persistence.Plugin.Contracts
{
    public interface IRepository<T> where T : class
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> Get(object specification);
    }
}
