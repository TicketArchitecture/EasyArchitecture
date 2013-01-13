using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Runtime.Plugin;
using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Instance
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

