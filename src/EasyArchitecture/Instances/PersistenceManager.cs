using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    public class PersistenceManager
    {
        private readonly EasyConfig _easyConfig;

        internal PersistenceManager(EasyConfig easyConfig)
        {
            _easyConfig = easyConfig;

            //get plugin
            var plugin = (IPersistencePlugin)_easyConfig.Plugins[typeof(IPersistencePlugin)];

            //execute
            plugin.Configure( _easyConfig.ModuleName,"",_easyConfig.InfrastructureAssembly);
        }

        internal object GetSession()
        {
            //get plugin
            var plugin = (IPersistencePlugin)_easyConfig.Plugins[typeof(IPersistencePlugin)];

            var moduleName = LocalThreadStorage.GetCurrentBusinessModuleName();
            //execute
            var session = LocalThreadStorage.RecoverSession(moduleName) ?? plugin.GetSession(_easyConfig.ModuleName);

            return session;
        }

        internal void BeginTransaction(string businessModuleName)
        {
            var session = GetSession();

            //get plugin
            var plugin = (IPersistencePlugin)_easyConfig.Plugins[typeof(IPersistencePlugin)];
            
            //execute
            plugin.BeginTransaction(session);

            LocalThreadStorage.StoreSession(businessModuleName, session);
        }

        internal void CommitTransaction(string businessModuleName)
        {
            var session = LocalThreadStorage.RecoverSession(businessModuleName);

            //get plugin
            var plugin = (IPersistencePlugin)_easyConfig.Plugins[typeof(IPersistencePlugin)];

            //execute
            plugin.CommitTransaction(session);

            LocalThreadStorage.ClearSession(businessModuleName);
        }

        internal void RollbackTransaction(string businessModuleName)
        {
            var session = LocalThreadStorage.RecoverSession(businessModuleName);

            //get plugin
            var plugin = (IPersistencePlugin)_easyConfig.Plugins[typeof(IPersistencePlugin)];

            //execute
            plugin.RollbackTransaction(session);

            LocalThreadStorage.ClearSession(businessModuleName);
        }
    }
}
