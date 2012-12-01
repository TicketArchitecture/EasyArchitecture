using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public static class PersistenceManager
    {
     
        public static object GetSession()
        {
            //discover
            //discovery instance
            var moduleName = LocalThreadStorage.GetCurrentBusinessModuleName();

            //execute
            return EasyConfigurations.Configurations[moduleName].Persistence.GetSession();
        }

    }
}
