using System;
using EasyArchitecture.Core;
using EasyArchitecture.Core.IO;

namespace EasyArchitecture.Mechanisms.Caching.Expressions
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
            var instance = InstanceProvider.GetInstance<Instances.Caching.Cache>();

            if (_timeSpan.Ticks==0)
            {
                instance.Add(key, _item);
            }else
            {
                instance.Add(key, _item, _timeSpan);
            }
        }
        
        public void At(object key)
        {
            At(SerializationHelper.Mount(key));
        }
    }
}