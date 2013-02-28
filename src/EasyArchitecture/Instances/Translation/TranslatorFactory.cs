using EasyArchitecture.Core;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.Translation;

namespace EasyArchitecture.Instances.Translation
{
    internal class TranslatorFactory : IProviderFactory<Translator>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private ITranslatorPlugin _plugin;

        public TranslatorFactory(ModuleAssemblies  moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            _plugin = pluginConfiguration.GetPlugin<ITranslatorPlugin>();
            _plugin.Configure(_moduleAssemblies, out pluginInspector);
        }

        public Translator GetInstance()
        {
            return new Translator(_plugin.GetInstance()); ;
        }
    }
}

