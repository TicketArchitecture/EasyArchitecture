using System.Collections.Generic;

namespace EasyArchitecture.Persistence
{
    public interface IRepository<T>
    {
        void Save(T o);
        void Update(T o);
        void Delete(T o);
        IList<T> Get(T qbe);
        IList<T> Get();

    }
}
