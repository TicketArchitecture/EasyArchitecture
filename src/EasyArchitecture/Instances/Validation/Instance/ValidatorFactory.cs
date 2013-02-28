using EasyArchitecture.Core;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.Validation;

namespace EasyArchitecture.Instances.Validation.Instance
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

