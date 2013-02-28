using System.Collections.Generic;

namespace EasyArchitecture.Plugin.Contracts.Persistence
{
    public interface IPersistence
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Save(object entity);
        void Update(object entity);
        void Delete(object entity);
        IList<T> Get<T>(object example);
        IList<T> Get<T>();
    }
}