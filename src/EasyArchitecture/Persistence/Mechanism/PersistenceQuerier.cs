using System.Collections.Generic;
using EasyArchitecture.IoC.Mechanism;
using EasyArchitecture.Persistence.Plugin.BultIn;

namespace EasyArchitecture.Persistence.Mechanism
{
    public static class PersistenceQuerier
    {
       public static IList<T> Execute<T>(string namedQuery, params object[] @params)
        {
            var querier = ServiceLocator.Resolve<Querier<T>>();
            var ret = querier.Execute(namedQuery, @params);
            return ret;
        }
    }
}