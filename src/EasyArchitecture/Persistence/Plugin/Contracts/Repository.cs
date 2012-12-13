using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Persistence.Plugin.Contracts
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
