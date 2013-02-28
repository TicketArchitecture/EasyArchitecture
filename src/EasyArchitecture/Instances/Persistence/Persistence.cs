using System.Collections.Generic;
using EasyArchitecture.Core.Log;
using EasyArchitecture.Plugin.Contracts.Persistence;

namespace EasyArchitecture.Instances.Persistence
{
    internal class Persistence
    {
        private readonly IPersistence _plugin;

        //TODO: must be internal but i did to activator use
        public Persistence(IPersistence plugin)
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

            InstanceLogger.Log(this, "Update", entity);
        }
    
        internal void Delete(object entity)
        {
            _plugin.Delete(entity);

            InstanceLogger.Log(this, "Delete", entity);
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
