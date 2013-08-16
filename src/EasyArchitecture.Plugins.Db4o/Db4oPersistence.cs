using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using EasyArchitecture.Plugins.Contracts.Persistence;

namespace EasyArchitecture.Plugins.Db4o
{
    public class Db4oPersistence : IPersistence
    {
        private readonly string _path;
        private IEmbeddedObjectContainer _db;


        public Db4oPersistence(string path)
        {
            _path = path;
        }

        public void BeginTransaction()
        {
            var cfg = Db4oEmbedded.NewConfiguration();
            cfg.Common.UpdateDepth = int.MaxValue;
            _db = Db4oEmbedded.OpenFile(cfg, _path);
        }

        public void CommitTransaction()
        {
            _db.Commit();
            _db.Close();
        }

        public void RollbackTransaction()
        {
            _db.Rollback();
            _db.Close();
        }

        public void Save(object entity)
        {
            if (_db == null)
                BeginTransaction();

            _db.Store(entity);
        }

        public void Update(object entity)
        {
            if (_db == null)
                BeginTransaction();

            _db.Store(entity);
        }

        public void Delete(object entity)
        {
            if (_db == null)
                BeginTransaction();

            _db.Delete(entity);
        }

        public IList<T> Get<T>(object example)
        {
            if (_db == null)
                BeginTransaction();

            return _db.QueryByExample(example).Cast<T>().ToList<T>();
        }

        public IList<T> Get<T>()
        {
            if (_db == null)
                BeginTransaction();

            return _db.Query<T>().ToList<T>();
        }

        public object GetUnderlayerPersistenceObject()
        {
            if (_db == null)
                BeginTransaction();

            return _db;
        }
    }
}
