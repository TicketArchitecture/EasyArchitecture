using System;
using System.Collections;

namespace EasyArchitecture.Data
{
    public class GenericResultTransformer<T> : NHibernate.Transform.IResultTransformer
    {
        private readonly Func<object[], string[], T> _transformation;

        public GenericResultTransformer(Func<object[], string[], T> transformation)
        {
            _transformation = transformation;
        }
        public GenericResultTransformer(Func<object[], T> transformation)
        {
            _transformation = (tuple, aliases) => transformation(tuple);
        }
        public IList TransformList(IList collection)
        {
            return collection;
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            return _transformation(tuple, aliases);
        }
    }
}