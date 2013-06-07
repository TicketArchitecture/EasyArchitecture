using System;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Caching;

namespace EasyArchitecture.Instances.Caching
{
    internal class Cache
    {
        private readonly ICache _plugin;

        internal Cache(ICache plugin)
        {
            _plugin = plugin;
        }

        internal void Add(string key, object item)
        {
            _plugin.Add(key, item);

            InstanceLogger.Log(this,"Add",key,item);
        }

        internal void Add(string key, object item, TimeSpan expiration)
        {
            _plugin.Add(key, item, expiration);

            InstanceLogger.Log(this, "Add", key, item, expiration);
        }

        internal void Remove(string key)
        {
            _plugin.Remove(key);

            InstanceLogger.Log(this, "Remove", key);
        }

        internal void Flush()
        {
            _plugin.Flush();

            InstanceLogger.Log(this, "Flush");
        }

        internal object GetData(string key)
        {
            var ret= _plugin.GetData(key);

            InstanceLogger.Log(this, "GetData",key,ret);

            return ret;
        }

        internal bool Contains(string key)
        {
            var ret = _plugin.Contains(key);

            InstanceLogger.Log(this, "Contains", key, ret);

            return ret;
        }
    }
}
