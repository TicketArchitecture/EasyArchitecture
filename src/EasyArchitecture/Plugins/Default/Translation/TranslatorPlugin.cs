using System.Reflection;

namespace EasyArchitecture.Plugins.Default.Translation
{
    public class TranslatorPlugin:ITranslatorPlugin
    {
        public void Configure(Assembly assembly)
        {
            //locale maprules classes
            //throw new NotImplementedException();
        }

        public T1 Map<T, T1>(T p0)
        {
            return Translator.Translate<T, T1>(p0);
        }

        public T1 Map<T, T1>(T p0, T1 p1)
        {
            return Translator.Translate<T, T1>(p0,p1);
        }
    }
}