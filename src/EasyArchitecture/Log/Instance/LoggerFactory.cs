using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Runtime.Contracts;

namespace EasyArchitecture.Log.Instance
{
    internal class LoggerFactory : IProviderFactory<Logger>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _easyCofig;
        private ILoggerPlugin _plugin;

        public LoggerFactory(ModuleAssemblies easyCofig)
        {
            _easyCofig = easyCofig;
        }

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<ILoggerPlugin>();
            _plugin.Configure(_easyCofig.InfrastructureAssembly);
        }

        public Logger GetInstance()
        {
            return new Logger(_plugin.GetInstance()); ;
        }
    }
}

