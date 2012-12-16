using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
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

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<ITranslatorPlugin>();
            _plugin.Configure(_moduleAssemblies);
        }

        public Translator GetInstance()
        {
            return new Translator(_plugin.GetInstance()); ;
        }
    }
}

