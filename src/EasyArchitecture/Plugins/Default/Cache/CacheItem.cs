using System;

namespace EasyArchitecture.Plugins.Default.Cache
{
    internal class CacheItem
    {
        internal CacheItem(object item,DateTime? expiration)
        {
            Item = item;
            ExpirationDate = expiration;
        }

        internal DateTime? ExpirationDate;
        internal object Item;
    }
}