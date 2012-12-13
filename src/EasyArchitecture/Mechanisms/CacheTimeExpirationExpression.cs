using System;

namespace EasyArchitecture.Mechanisms
{
    public class CacheTimeExpirationExpression
    {
        private readonly object _item;
        private readonly int _value;

        public CacheTimeExpirationExpression(object item, int timeValue)
        {
            _item = item;
            _value = timeValue;
        }

        public CacheAtExpression Seconds
        {
            get { return new CacheAtExpression(_item, new TimeSpan(0, 0, 0, _value)); }
        }

        public CacheAtExpression Minutes
        {
            get { return new CacheAtExpression(_item, new TimeSpan(0, 0, _value, 0)); }
        }

        public CacheAtExpression Hours
        {
            get { return new CacheAtExpression(_item, new TimeSpan(0, _value, 0, 0)); }
        }

        public CacheAtExpression Days
        {
            get { return new CacheAtExpression(_item, new TimeSpan(_value, 0, 0, 0)); }
        }
    }
}