using System;
using EasyArchitecture.Caching.Plugin.Contracts;

namespace EasyArchitecture.Caching.Instance
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
        }

        internal void Add(string key, object item, TimeSpan expiration)
        {
            _plugin.Add(key, item, expiration);
        }

        internal void Remove(string key)
        {
            _plugin.Remove(key);
        }

        internal void Flush()
        {
            _plugin.Flush();
        }

        internal object GetData(string key)
        {
            return _plugin.GetData(key);
        }

        internal bool Contains(string key)
        {
            return _plugin.Contains(key);
        }
    }
}
