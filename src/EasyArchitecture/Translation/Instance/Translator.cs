using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Instance
{
    internal class Translator
    {
        private readonly ITranslator _plugin;

        internal Translator(ITranslator plugin)
        {
            _plugin = plugin;
        }

        internal T1 Translate<T, T1>(T p0)
        {
            return _plugin.Translate<T,T1>(p0);
        }

        internal T1 Translate<T, T1>(T p0, T1 obj1)
        {
            return _plugin.Translate(p0, obj1);
        }
    }
}