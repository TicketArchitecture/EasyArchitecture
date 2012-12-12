using System;

namespace EasyArchitecture.Instances
{
    public class Cache
    {
//                private static readonly ICacheManager CacheInstance = CacheFactory.GetCacheManager();

        public void Add(string key, object obj)
        {
            //CacheInstance.Add(key,obj);
        }

        public void Add(string key, object obj, TimeSpan expiration)
        {
            //CacheInstance.Add(key, obj, CacheItemPriority.Normal, null, new SlidingTime(expiration));
        }

        public void Remove(string key)
        {
            //CacheInstance.Remove(key);
        }

        public void Flush()
        {
            //CacheInstance.Flush();
        }

        public object GetData(string key)
        {
            //return CacheInstance.GetData(key);
            return null;
        }

        public T GetData<T>(string key)
        {
            //return (T)CacheInstance.GetData(key);
            return default(T);
        }

        public bool Contains(string key)
        {
            //return CacheInstance.Contains(key);
            return false;
        }
    }
    
}
