using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Translation.Expressions
{
    public class ToExpression<T>
    {
        private readonly T _obj;

        internal ToExpression(T obj)
        {
            _obj = obj;
        }

        public T1 To<T1>()
        {
            //return EasyConfigurations.Selector<T>().Translator.Translate<T, T1>(_obj);
            return ConfigurationSelector.SelectorByThread().Translator.Translate<T, T1>(_obj);
        }

        public T1 To<T1>(T1 obj)
        {
            //return EasyConfigurations.Selector<T>().Translator.Translate(_obj, obj);
            return ConfigurationSelector.SelectorByThread().Translator.Translate(_obj, obj);
        }
    }
}