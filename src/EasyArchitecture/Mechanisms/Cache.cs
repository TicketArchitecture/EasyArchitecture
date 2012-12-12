using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyArchitecture.Mechanisms
{
    public class Cache
    {
        //private static readonly ICacheManager CacheInstance = CacheFactory.GetCacheManager();
        private static readonly EasyArchitecture.Instances.Cache CacheInstance = new EasyArchitecture.Instances.Cache();

        public static void Add(string key, object obj)
        {
            CacheInstance.Add(key, obj);
        }

        public static void Add(string key, object obj, TimeSpan expiration)
        {
            //CacheInstance.Add(key, obj, CacheItemPriority.Normal, null, new SlidingTime(expiration));
        }

        public static void Remove(string key)
        {
            CacheInstance.Remove(key);
        }

        public static void Flush()
        {
            CacheInstance.Flush();
        }

        public static object GetData(string key)
        {
            return CacheInstance.GetData(key);
        }

        public static T GetData<T>(string key)
        {
            return (T)CacheInstance.GetData(key);
        }

        public static bool Contains(string key)
        {
            return CacheInstance.Contains(key);
        }
    }
}

