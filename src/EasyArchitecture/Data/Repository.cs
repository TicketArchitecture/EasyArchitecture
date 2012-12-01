using EasyArchitecture.Mechanisms;

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
