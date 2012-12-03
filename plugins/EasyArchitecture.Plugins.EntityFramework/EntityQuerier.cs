using System.Data.Entity;
using EasyArchitecture.Common.Persistence;

namespace EasyArchitecture.Plugins.EntityFramework
{
    public abstract class EntityQuerier<T> : QuerierBase<T>
    {

        private DbContext GetLocalSession()
        {
            return (DbContext)base.GetSession();
        }


        //protected ISQLQuery CreateSqlQuery(string queryString)
        //{
        //    return GetLocalSession().CreateSQLQuery(queryString);
        //}
    }
}


