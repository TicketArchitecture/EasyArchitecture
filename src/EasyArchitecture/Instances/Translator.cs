using EasyArchitecture.Internal;
using EasyArchitecture.Mechanisms;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class Translator
    {
        private readonly EasyConfig _easyCofig;

        internal Translator(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            //get plugin
            var plugin = (IObjectMapperPlugin)_easyCofig.Plugins[typeof(IObjectMapperPlugin)];

            //configure
            plugin.Configure(_easyCofig.InfrastructureAssembly);
        }

        internal T1 Translate<T, T1>(T p0)
        {
            //get plugin
            var plugin = (IObjectMapperPlugin) _easyCofig.Plugins[typeof (IObjectMapperPlugin)];
            //execute
            return plugin.Map<T,T1>(p0);
        }

        internal T1 Translate<T, T1>(T p0, T1 obj1)
        {
            //get plugin
            var plugin = (IObjectMapperPlugin)_easyCofig.Plugins[typeof(IObjectMapperPlugin)];
            //execute
            return plugin.Map(p0, obj1);
        }
    }
}