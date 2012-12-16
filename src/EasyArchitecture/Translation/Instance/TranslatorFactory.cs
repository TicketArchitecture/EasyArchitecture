using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Instance
{
    internal class TranslatorFactory : IProviderFactory<Translator>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _easyCofig;
        private ITranslatorPlugin _plugin;

        public TranslatorFactory(ModuleAssemblies easyCofig)
        {
            _easyCofig = easyCofig;
        }

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<ITranslatorPlugin>();
            _plugin.Configure(_easyCofig.InfrastructureAssembly);
        }

        public Translator GetInstance()
        {
            return new Translator(_plugin.GetInstance()); ;
        }
    }
}

