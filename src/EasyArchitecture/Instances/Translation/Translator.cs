using EasyArchitecture.Core;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Plugins.Contracts.Translation;

namespace EasyArchitecture.Instances.Translation
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
            var ret=_plugin.Translate<T,T1>(p0);

            InstanceLogger.Log(this, "Translate" ,typeof(T).Name , p0, typeof(T1).Name, ret);

            return ret;
        }

        internal T1 Translate<T, T1>(T p0, T1 obj1)
        {
            var ret=_plugin.Translate(p0, obj1);

            InstanceLogger.Log(this, "Translate", typeof(T).Name, p0, typeof(T1).Name, ret);

            return ret;
        }
    }
}