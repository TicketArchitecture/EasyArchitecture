using System.Collections.Generic;
using EasyArchitecture.Mechanisms;

namespace EasyArchitecture.Data
{
    public abstract class QuerierBase<T>
    {
        public abstract IList<T> Execute(NamedQuery<T> namedQuery);

        protected object GetSession()
        {
            return PersistenceManager.GetSession();
        }

    }
}


