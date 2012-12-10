using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class TranslatorToExpression<T>
    {
        private readonly T _obj;

        internal TranslatorToExpression(T obj)
        {
            _obj = obj;
        }

        public T1 To<T1>()
        {
            //return EasyConfigurations.Selector<T>().Translator.Translate<T, T1>(_obj);
            return EasyConfigurations.SelectorByThread().Translator.Translate<T, T1>(_obj);
        }

        public T1 To<T1>(T1 obj)
        {
            //return EasyConfigurations.Selector<T>().Translator.Translate(_obj, obj);
            return EasyConfigurations.SelectorByThread().Translator.Translate(_obj, obj);
        }
    }
}