using System.Collections.Generic;

namespace EasyArchitecture.Persistence
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> Get(T example);
        IList<T> Get();
    }
}
