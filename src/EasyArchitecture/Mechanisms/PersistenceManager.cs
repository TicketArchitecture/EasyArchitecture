using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public static class PersistenceManager
    {
        public static object GetSession()
        {
            return EasyConfigurations.SelectorByThread().Persistence.GetSession();
        }

    }
}
