﻿using System.Collections.Generic;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime.Log;

namespace EasyArchitecture.Persistence.Instance
{
    internal class Persistence
    {
        private readonly IPersistence _plugin;

        internal Persistence(IPersistence plugin)
        {
            _plugin = plugin;
        }

        internal void BeginTransaction()
        {
            _plugin.BeginTransaction();

            InstanceLogger.Log(this, "BeginTransaction");
        }

        internal void CommitTransaction()
        {
            _plugin.CommitTransaction();

            InstanceLogger.Log(this, "CommitTransaction");
        }

        internal void RollbackTransaction()
        {
            _plugin.RollbackTransaction();

            InstanceLogger.Log(this, "RollbackTransaction");
        }

        internal void Save(object entity)
        {
            _plugin.Save(entity);
            
            InstanceLogger.Log(this, "Save",entity);
        }
    
        internal void Update(object entity)
        {
            _plugin.Update(entity);

            InstanceLogger.Log(this, "Save", entity);
        }
    
        internal void Delete(object entity)
        {
            _plugin.Delete(entity);

            InstanceLogger.Log(this, "Save", entity);
        }

        internal IList<T> Get<T>(object example)
        {
            var list = _plugin.Get<T>(example);

            InstanceLogger.Log(this, "Get", example, list);

            return list;
        }

        internal IList<T> Get<T>()
        {
            var list=_plugin.Get<T>();

            InstanceLogger.Log(this, "Get", list);

            return list;
        }

    }
}
