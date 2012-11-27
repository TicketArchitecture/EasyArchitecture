using System;
using System.Collections.Generic;
using EasyArchitecture.Initialization;

namespace EasyArchitecture.Data
{
    public static class Querier
    {
        public static IList<T> Execute<T>(NamedQuery<T> namedQuery)
        {
         //   Type U = typeof (NamedQuery<T>);
            //get querier 4 T
            var querier = Bootstrap.GetInstance().GetInstance<NHibernateQuerier<T>>();

            //execute
            //var ret = new NHibernateQuerier<T>().Execute(namedQuery);
            var ret = querier.Execute(namedQuery);

            return ret;
            
        }

    }
}