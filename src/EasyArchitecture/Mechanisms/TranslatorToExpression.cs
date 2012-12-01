using EasyArchitecture.Initialization;

namespace EasyArchitecture.Mechanisms
{
    public class TranslatorToExpression<T>
    {
        private readonly T _obj;

        public TranslatorToExpression(T obj)
        {
            _obj = obj;
        }

        public T1 To<T1>()
        {
            //return Translator.GetInstanceOf(AssemblyManager.ModuleName<T>()).Translate<T, T1>(_obj);
            //discovery instance
            var moduleName = AssemblyManager.ModuleName<T>();
            //execute
            return Internal.EasyConfigurations.Configurations[moduleName].Translator.Translate<T, T1>(_obj);
        }

        public T1 To<T1>(T1 obj)
        {
            //return Translator.GetInstanceOf(AssemblyManager.ModuleName<T>()).Translate(_obj, obj);
            //discovery instance
            var moduleName = AssemblyManager.ModuleName<T>();
            //execute
            return Internal.EasyConfigurations.Configurations[moduleName].Translator.Translate(_obj, obj);

        }
    }
}