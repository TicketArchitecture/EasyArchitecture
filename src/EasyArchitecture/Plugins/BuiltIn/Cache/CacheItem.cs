using System;

namespace EasyArchitecture.Plugins.BuiltIn.Cache
{
    internal class CacheItem
    {
        internal readonly DateTime? ExpirationDate;
        internal readonly object Item;

        internal CacheItem(object item, DateTime? expiration)
        {
            Item = item;
            ExpirationDate = expiration;
        }
    }
}