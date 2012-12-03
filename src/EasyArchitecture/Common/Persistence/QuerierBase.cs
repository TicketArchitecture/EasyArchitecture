using System.Collections.Generic;
using EasyArchitecture.Mechanisms;

namespace EasyArchitecture.Common.Persistence
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


