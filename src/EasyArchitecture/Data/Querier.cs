using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace EasyArchitecture.Data
{
    public static class Querier
    {
        public static IList<T> Execute<T>(NamedQuery<T> namedQuery)
        {
         //   Type U = typeof (NamedQuery<T>);
            //get querier 4 T
            var querier = ServiceLocator.Current.GetInstance<NHibernateQuerier<T>>();

            //execute
            //var ret = new NHibernateQuerier<T>().Execute(namedQuery);
            var ret = querier.Execute(namedQuery);

            return ret;
            
        }

    }
}