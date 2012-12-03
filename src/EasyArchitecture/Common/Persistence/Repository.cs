using EasyArchitecture.Mechanisms;

namespace EasyArchitecture.Common.Persistence
{
    public abstract class Repository<T> where T : class
    {
        protected object GetSession()
        {
            return PersistenceManager.GetSession();
        }
    }
}
