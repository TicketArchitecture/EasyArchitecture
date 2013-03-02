using System;
using System.Collections.Generic;
using EasyArchitecture.Plugins.Contracts.Caching;

namespace EasyArchitecture.Plugins.BultIn.Caching
{
    internal class Cache : ICache
    {
        private static readonly Dictionary<string, CacheItem> CacheData = new Dictionary<string, CacheItem>();

        public void Add(string key, object obj)
        {
            Add(key, obj, new TimeSpan(1001,0,0,0));
        }

        public void Add(string key, object obj, TimeSpan expiration)
        {
            if (ConfirmExistence(key))
                CacheData.Remove(key);

            CacheData.Add(key, new CacheItem(obj, DateTime.Now.Add(expiration)));
        }

        public void Remove(string key)
        {
            CacheData.Remove(key);
        }

        public void Flush()
        {
            CacheData.Clear();
        }

        public object GetData(string key)
        {
            return ConfirmExistence(key) ? CacheData[key].Item : null;
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
            if (!CacheData.ContainsKey(key)) return;

            var item = CacheData[key];
            if (item.ExpirationDate<=DateTime.Now)
            {
                CacheData.Remove(key);
            }
        }

        private bool ConfirmExistence(string key)
        {
            VerifyExpiration(key);
            return (CacheData.ContainsKey(key));
        }
    }
}
