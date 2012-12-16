using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Instance
{
    internal class ValidatorFactory : IProviderFactory<Validator>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _easyCofig;
        private IValidatorPlugin _plugin;

        public ValidatorFactory(ModuleAssemblies easyCofig)
        {
            _easyCofig = easyCofig;
        }

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<IValidatorPlugin>();
            _plugin.Configure(_easyCofig.InfrastructureAssembly);
        }

        public Validator GetInstance()
        {
            return new Validator(_plugin.GetInstance()); ;
        }
    }
}

