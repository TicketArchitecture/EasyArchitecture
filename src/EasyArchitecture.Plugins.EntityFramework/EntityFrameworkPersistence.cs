using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using EasyArchitecture.Plugins.Contracts.Persistence;

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
            _dbContext.SaveChanges();
        }

        public void Update(object entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object entity)
        {
            _dbContext.Set(entity.GetType()).Remove(entity);
            _dbContext.SaveChanges();
        }

        public IList<T> Get<T>(object example) 
        {
            var queryable = (IQueryable<T>)_dbContext.Set(typeof(T));
            var type = typeof(T);


            var parameterExpression = Expression.Parameter(type, "p");

            var expressions= (from property in type.GetProperties() let exampleValue = property.GetValue(example, BindingFlags.Default, null, null, null) where !CommonRules.ShouldNotUseForComparison(exampleValue, property) select Expression.Equal(Expression.Property(parameterExpression, property.Name), Expression.Constant(exampleValue))).Cast<Expression>().ToList();

            var query = queryable.Where(x => true); 
            if (expressions.Count > 0)
            {
                var compExpression = expressions[0];
                
                compExpression = expressions.Skip(1).Aggregate(compExpression, Expression.AndAlso);

                query = queryable.Where(Expression.Lambda<Func<T, bool>>(compExpression, parameterExpression));
            }

            return new List<T>(query);
        }

        public IList<T> Get<T>()
        {
            return new List<T>((IEnumerable<T>)_dbContext.Set(typeof(T)));
        }

        public object GetUnderlayerPersistenceObject()
        {
            return _dbContext;
        }
    }
}
