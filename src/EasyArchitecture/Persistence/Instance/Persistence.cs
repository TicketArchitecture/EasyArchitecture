using EasyArchitecture.Persistence.Plugin.Contracts;

namespace EasyArchitecture.Persistence.Instance
{
    internal class Persistence
    {
        private readonly IPersistence _plugin;
        private object session;

        internal Persistence(IPersistence plugin)
        {
            _plugin = plugin;
            
        }

        internal object GetSession()
        {
            session = _plugin.GetSession("");
            return session;
        }

        internal void BeginTransaction()
        {
            _plugin.BeginTransaction(session);
        }

        internal void CommitTransaction()
        {
            _plugin.CommitTransaction(session);
        }

        internal void RollbackTransaction()
        {
            _plugin.RollbackTransaction(session);
        }
    }
}
