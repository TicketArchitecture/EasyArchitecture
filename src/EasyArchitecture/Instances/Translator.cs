using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class Translator
    {
        private readonly EasyConfig _easyCofig;
        private readonly IObjectMapperPlugin _plugin;

        internal Translator(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            _plugin = (IObjectMapperPlugin)_easyCofig.Plugins[typeof(IObjectMapperPlugin)];
            _plugin.Configure(_easyCofig.InfrastructureAssembly);
        }

        internal T1 Translate<T, T1>(T p0)
        {
            return _plugin.Map<T,T1>(p0);
        }

        internal T1 Translate<T, T1>(T p0, T1 obj1)
        {
            return _plugin.Map(p0, obj1);
        }
    }
}