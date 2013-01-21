﻿using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime.Log;

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

            InstanceLogger.Log(this, "GetSession", _session.GetHashCode());

            return _session;
        }

        internal void BeginTransaction()
        {
            this.GetSession();
            _plugin.BeginTransaction(_session);

            InstanceLogger.Log(this, "BeginTransaction");
        }

        internal void CommitTransaction()
        {
            _plugin.CommitTransaction(_session);

            InstanceLogger.Log(this, "CommitTransaction");
        }

        internal void RollbackTransaction()
        {
            _plugin.RollbackTransaction(_session);

            InstanceLogger.Log(this, "RollbackTransaction");
        }
    }
}
