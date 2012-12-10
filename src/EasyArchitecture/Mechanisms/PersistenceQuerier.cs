using System.Collections.Generic;
using EasyArchitecture.Common.Persistence;

namespace EasyArchitecture.Mechanisms
{
    public static class PersistenceQuerier
    {
       public static IList<T> Execute<T>(string namedQuery, params object[] @params)
        {
            var querier = DependencyInjection.Resolve<Querier<T>>();
            var ret = querier.Execute(namedQuery, @params);
            return ret;
        }
    }
}