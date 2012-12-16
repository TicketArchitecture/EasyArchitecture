using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Instance
{
    internal class ValidatorFactory : IProviderFactory<Validator>, IRegisterablePluginFactory
    {
        private readonly ModuleAssemblies _easyCofig;
        private IValidatorPlugin _plugin;

        public ValidatorFactory(ModuleAssemblies easyCofig)
        {
            _easyCofig = easyCofig;
        }

        //private readonly Dictionary<string,Type> Plugins = new Dictionary<string,Type>();
        //private readonly Dictionary<string, Type> PluginsInstances = new Dictionary<string, Type>();

        //internal void RegisterPlugin(string moduleName, IValidatorPlugin plugin)
        //{
        //    Plugins.Add(moduleName,plugin);
        //}


        public void RegisterPlugin(ConfigHelper config)
        {
            _plugin = config.GetPlugin<IValidatorPlugin>();
            _plugin.Configure(_easyCofig.InfrastructureAssembly);

            //_plugin = (IValidatorPlugin)plugin;
        }
        public Validator GetInstance()
        {
            return new Validator(_plugin.GetInstance()); ;
        }
    }

    internal interface IProviderFactory<T>
    {
        T GetInstance();
    }

    internal interface IRegisterablePluginFactory
    {
        void RegisterPlugin(ConfigHelper plugin);
    }
}

