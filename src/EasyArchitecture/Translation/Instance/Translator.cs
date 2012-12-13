using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Instance
{
    internal class Translator
    {
        private readonly EasyConfig _easyCofig;
        private readonly ITranslatorPlugin _plugin;

        internal Translator(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            _plugin = (ITranslatorPlugin)_easyCofig.Plugins[typeof(ITranslatorPlugin)];
            _plugin.Configure(_easyCofig.InfrastructureAssembly);
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