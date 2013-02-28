using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using EasyArchitecture.Plugin.Contracts.Persistence;

namespace EasyArchitecture.Plugins.EntityFramework
{
    public class EntityFrameworkPersistence : IPersistence
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkPersistence(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
        }

        public void CommitTransaction()
        {
            _dbContext.SaveChanges();
        }

        public void RollbackTransaction()
        {
            _dbContext.Dispose();
        }

        public void Save(object entity)
        {
            _dbContext.Set(entity.GetType()).Add(entity);
        }

        public void Update(object entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object entity)
        {
            _dbContext.Set(entity.GetType()).Remove(entity);
        }

        public IList<T> Get<T>(object example)
        {
            throw new NotImplementedException();
        }

        public IList<T> Get<T>()
        {
            throw new NotImplementedException();
        }

        public object GetUnderlayerPersistenceObject()
        {
            throw new NotImplementedException();
        }
    }
}
