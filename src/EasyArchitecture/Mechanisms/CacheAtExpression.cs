using System;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class CacheAtExpression
    {
        private readonly object _item;
        private readonly TimeSpan _timeSpan ;

        public CacheAtExpression(object item)
        {
            _item = item;
        }

        public CacheAtExpression(object item, TimeSpan timeSpan)
        {
            _item = item;
            _timeSpan = timeSpan;
        }

        public void At(string key)
        {
            var instance = EasyConfigurations.SelectorByThread().Cache;

            if (_timeSpan.Ticks==0)
            {
                instance.Add(key, _item);
            }else
            {
                instance.Add(key, _item, _timeSpan);
            }
        }
    }
}