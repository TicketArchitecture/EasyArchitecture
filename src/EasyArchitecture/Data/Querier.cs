using System.Collections.Generic;
using EasyArchitecture.Initialization;

namespace EasyArchitecture.Data
{
    public static class Querier
    {
        public static IList<T> Execute<T>(NamedQuery<T> namedQuery)
        {
            var querier = Bootstrap.GetInstance().GetInstance<QuerierBase<T>>();
            var ret = querier.Execute(namedQuery);

            return ret;
        }
    }
}