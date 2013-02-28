using System;

namespace EasyArchitecture.Mechanisms.Caching.Expressions
{
    public class TimeExpirationExpression
    {
        private readonly object _item;
        private readonly int _value;

        public TimeExpirationExpression(object item, int timeValue)
        {
            _item = item;
            _value = timeValue;
        }

        public AtExpression Seconds
        {
            get { return new AtExpression(_item, new TimeSpan(0, 0, 0, _value)); }
        }

        public AtExpression Minutes
        {
            get { return new AtExpression(_item, new TimeSpan(0, 0, _value, 0)); }
        }

        public AtExpression Hours
        {
            get { return new AtExpression(_item, new TimeSpan(0, _value, 0, 0)); }
        }

        public AtExpression Days
        {
            get { return new AtExpression(_item, new TimeSpan(_value, 0, 0, 0)); }
        }
    }
}