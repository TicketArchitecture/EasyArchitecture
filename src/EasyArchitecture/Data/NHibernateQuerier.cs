using NHibernate;

namespace EasyArchitecture.Data
{
    public abstract class NHibernateQuerier
    {
        protected ISQLQuery CreateSqlQuery(string queryString)
        {
            return PersistenceManager.GetSession().CreateSQLQuery(queryString);
        }

    }
}


