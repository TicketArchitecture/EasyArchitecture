using System;

namespace EasyArchitecture.Caching.Plugin.Contracts
{
    public interface ICachePlugin
    {
        void Add(string key, object obj);
        void Add(string key, object obj, TimeSpan expiration);
        void Remove(string key);
        void Flush();
        object GetData(string key);
        bool Contains(string key);
    }
}