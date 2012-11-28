using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyArchitecture.Data
{
    public abstract class Repository<T> where T : class
    {
        protected object GetSession()
        {
            return PersistenceManager.GetSession();
        }
    }
}
