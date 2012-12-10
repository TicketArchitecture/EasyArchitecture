using EasyArchitecture.Internal;

namespace EasyArchitecture.Common.Persistence
{
    public abstract class Repository<T> where T : class
    {
        protected object GetSession()
        {
            //return Persistence.GetSession();
            return EasyConfigurations.SelectorByThread().Persistence.GetSession();
        }
    }
}
