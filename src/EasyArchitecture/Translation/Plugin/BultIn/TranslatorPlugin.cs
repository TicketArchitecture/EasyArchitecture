using System.Collections.Generic;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;
using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Plugin.BultIn
{
    internal class TranslatorPlugin : AbstractPlugin, ITranslatorPlugin
    {
        private readonly List<TypeMap> MappedTypes = new List<TypeMap>();

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
        }

        public ITranslator GetInstance()
        {
            return new Translator(MappedTypes);
        }
    }
}
