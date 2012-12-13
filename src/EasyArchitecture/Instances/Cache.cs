using System;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    public class Cache
    {
        private readonly EasyConfig _easyCofig;
        private readonly ICachePlugin _plugin;

        internal Cache(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            _plugin = (ICachePlugin)_easyCofig.Plugins[typeof(ICachePlugin)];
        }

        public void Add(string key, object obj)
        {
            _plugin.Add(key, obj);
        }

        public void Add(string key, object obj, TimeSpan expiration)
        {
            _plugin.Add(key, obj, expiration);
        }

        public void Remove(string key)
        {
            _plugin.Remove(key);
        }

        public void Flush()
        {
            _plugin.Flush();
        }

        public object GetData(string key)
        {
            return _plugin.GetData(key);
        }

        public T GetData<T>(string key)
        {
            return _plugin.GetData<T>(key);
        }

        public bool Contains(string key)
        {
            return _plugin.Contains(key);
        }
    }
}
