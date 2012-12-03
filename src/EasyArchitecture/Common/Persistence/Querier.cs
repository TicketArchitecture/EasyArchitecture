using System.Collections.Generic;
using EasyArchitecture.Mechanisms;

namespace EasyArchitecture.Common.Persistence
{
    public static class Querier
    {
        public static IList<T> Execute<T>(NamedQuery<T> namedQuery)
        {
            var querier = DependencyInjection.Resolve<QuerierBase<T>>();
            var ret = querier.Execute(namedQuery);
            return ret;
        }
    }
}