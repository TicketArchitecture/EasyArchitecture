using System;

namespace EasyArchitecture.Plugins.Contracts.Caching
{
    public interface ICache
    {
        void Add(string key, object obj);
        void Add(string key, object obj, TimeSpan expiration);
        void Remove(string key);
        void Flush();
        object GetData(string key);
        bool Contains(string key);
    }
}