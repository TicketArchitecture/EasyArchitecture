using System;
using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtExpression
    {
        private readonly object _item;
        private readonly TimeSpan _timeSpan ;

        public AtExpression(object item)
        {
            _item = item;
        }

        public AtExpression(object item, TimeSpan timeSpan)
        {
            _item = item;
            _timeSpan = timeSpan;
        }

        public void At(string key)
        {
            var instance = ConfigurationSelector.SelectorByThread().Cache;

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