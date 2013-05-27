using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Translation.Expressions
{
    public class ToExpression<T>
    {
        private readonly T _obj;

        internal ToExpression(T obj)
        {
            _obj = obj;
        }

        public T1 Into<T1>()
        {
            return InstanceProvider.GetInstance<Instances.Translation.Translator>().Translate<T, T1>(_obj);
        }

        public T1 To<T1>(T1 obj)
        {
            return InstanceProvider.GetInstance<Instances.Translation.Translator>().Translate(_obj, obj);
        }
    }
}