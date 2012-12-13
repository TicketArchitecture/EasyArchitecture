using System;
using System.Collections.Generic;
using EasyArchitecture.Caching.Plugin.Contracts;

namespace EasyArchitecture.Caching.Plugin.BultIn
{
    internal class CachePlugin : ICachePlugin
    {
        private readonly Dictionary<string, CacheItem> _cache = new Dictionary<string, CacheItem>();

        public void Add(string key, object obj)
        {
            Add(key, obj, new TimeSpan(1001,0,0,0));
        }

        public void Add(string key, object obj, TimeSpan expiration)
        {
            if (ConfirmExistence(key))
                _cache.Remove(key);

            _cache.Add(key, new CacheItem(obj, DateTime.Now.Add(expiration)));
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Flush()
        {
            _cache.Clear();
        }

        public object GetData(string key)
        {
            return ConfirmExistence(key) ? _cache[key].Item : null;
        }

        public T GetData<T>(string key)
        {
            return  (T) GetData(key);
        }

        public bool Contains(string key)
        {
            return ConfirmExistence(key);
        }

        private void VerifyExpiration(string key)
        {
            if (!_cache.ContainsKey(key)) return;

            var item = _cache[key];
            if (item.ExpirationDate<=DateTime.Now)
            {
                _cache.Remove(key);
            }
        }

        private bool ConfirmExistence(string key)
        {
            VerifyExpiration(key);
            return (_cache.ContainsKey(key));
        }
    }
}
