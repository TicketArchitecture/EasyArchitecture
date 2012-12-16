using EasyArchitecture.Persistence.Plugin.Contracts;

namespace EasyArchitecture.Persistence.Instance
{
    internal class Persistence
    {
        private readonly IPersistence _plugin;

        internal Persistence(IPersistence plugin)
        {
            _plugin = plugin;
        }

        internal object GetSession()
        {
            //return LocalThreadStorage.RecoverSession(_moduleName) ?? _plugin.GetSession(_moduleName);
            return null;
        }

        internal void BeginTransaction()
        {
            var session = GetSession();

            _plugin.BeginTransaction(session);

            //LocalThreadStorage.StoreSession(_moduleName, session);
        }

        internal void CommitTransaction()
        {
            //var session = LocalThreadStorage.RecoverSession(_moduleName);

            //_plugin.CommitTransaction(session);

            //LocalThreadStorage.ClearSession(_moduleName);
        }

        internal void RollbackTransaction()
        {
            //var session = LocalThreadStorage.RecoverSession(_moduleName);

            //_plugin.RollbackTransaction(session);

            //LocalThreadStorage.ClearSession(_moduleName);
        }
    }
}
