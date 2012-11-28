using EasyArchitecture.Data;
using NHibernate;

namespace EasyArchitecture.Plugins.NHibernate
{
    public abstract class NHibernateQuerier<T> : QuerierBase<T>
    {

        private ISession GetLocalSession()
        {
            return (ISession) base.GetSession();
        }


        protected ISQLQuery CreateSqlQuery(string queryString)
        {
            return GetLocalSession().CreateSQLQuery(queryString);
        }
    }
}


