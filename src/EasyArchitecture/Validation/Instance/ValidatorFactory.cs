using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Runtime.Plugin;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Instance
{
    internal class ValidatorFactory : IProviderFactory<Validator>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private IValidatorPlugin _plugin;

        public ValidatorFactory(ModuleAssemblies moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            _plugin = pluginConfiguration.GetPlugin<IValidatorPlugin>();
            _plugin.Configure(_moduleAssemblies, out pluginInspector);
        }

        public Validator GetInstance()
        {
            return new Validator(_plugin.GetInstance()); ;
        }
    }
}

