using System.Collections.Generic;
using NHibernate;

namespace EasyArchitecture.Data
{
    public abstract class NHibernateQuerier<T>
    {
        public abstract IList<T> Execute(NamedQuery<T> namedQuery);

        protected ISQLQuery CreateSqlQuery(string queryString)
        {
            return PersistenceManager.GetSession().CreateSQLQuery(queryString);
        }
    }
}


