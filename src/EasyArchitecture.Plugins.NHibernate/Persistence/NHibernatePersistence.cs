using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Plugin.Contracts.Persistence;
using NHibernate;
using NHibernate.Criterion;

namespace EasyArchitecture.Plugins.NHibernate.Persistence
{
    public class NHibernatePersistence : IPersistence
    {
        private readonly ISession _session;

        public NHibernatePersistence(ISession session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            if (_session != null) _session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_session != null)
            {
                _session.Transaction.Commit();
                _session.Flush();
                _session.Close();
            }
        }

        public void RollbackTransaction()
        {
            if (_session == null) return;
            _session.Transaction.Rollback();
            _session.Close();
        }

        public void Save(object entity)
        {
            _session.Save(entity);
        }

        public void Update(object entity)
        {
            _session.Update(entity);
        }

        public void Delete(object entity)
        {
            _session.Delete(entity);
            _session.Flush();
        }

        public IList<T> Get<T>(object example)
        {
            var type = typeof(T);
            var criteria = _session.CreateCriteria(type);

            foreach (var property in type.GetProperties())
            {
                var exampleValue = property.GetValue(example, BindingFlags.Default, null, null, null);

                //ignore all these non initialized properties, as well as boolean ones
                if (exampleValue == null || exampleValue is bool || exampleValue.Equals(0) || exampleValue.Equals(string.Empty))
                    continue;

                criteria.Add(Restrictions.Eq(property.Name, exampleValue));
            }
            return criteria.List<T>();
        }

        public IList<T> Get<T>()
        {
            return _session.CreateCriteria(typeof(T)).List<T>();
        }
    }
}
