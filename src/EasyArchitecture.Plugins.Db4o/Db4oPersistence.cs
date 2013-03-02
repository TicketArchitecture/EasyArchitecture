using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using EasyArchitecture.Plugins.Contracts.Persistence;

namespace EasyArchitecture.Plugins.Db4o
{
    public class Db4oPersistence : IPersistence
    {
        private readonly IObjectContainer _db;

        public Db4oPersistence(IObjectContainer db)
        {
            _db = db;
        }

        public void BeginTransaction()
        {
            
        }

        public void CommitTransaction()
        {
            _db.Commit();
        }

        public void RollbackTransaction()
        {
            _db.Rollback();
        }

        public void Save(object entity)
        {
            _db.Store(entity);
        }

        public void Update(object entity)
        {
            _db.Store(entity);
        }

        public void Delete(object entity)
        {
            _db.Delete(entity);
        }

        public IList<T> Get<T>(object example)
        {
            return _db.QueryByExample(example).Cast<T>().ToList<T>();
        }

        public IList<T> Get<T>()
        {
            return _db.Query<T>().ToList<T>();
        }

        public object GetUnderlayerPersistenceObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
