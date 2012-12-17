using EasyArchitecture.Persistence.Plugin.Contracts;

namespace EasyArchitecture.Persistence.Instance
{
    internal class Persistence
    {
        private readonly IPersistence _plugin;
        private object _session;

        internal Persistence(IPersistence plugin)
        {
            _plugin = plugin;
        }

        internal object GetSession()
        {
            if (_session == null)
                _session = _plugin.GetSession("");
            return _session;
        }

        internal void BeginTransaction()
        {
            this.GetSession();
            _plugin.BeginTransaction(_session);
        }

        internal void CommitTransaction()
        {
            _plugin.CommitTransaction(_session);
        }

        internal void RollbackTransaction()
        {
            _plugin.RollbackTransaction(_session);
        }
    }
}
