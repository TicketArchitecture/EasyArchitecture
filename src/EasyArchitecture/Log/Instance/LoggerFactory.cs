using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Log.Instance
{
    internal class LoggerFactory : IProviderFactory<Logger>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private ILoggerPlugin _plugin;

        public LoggerFactory(ModuleAssemblies moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            _plugin = pluginConfiguration.GetPlugin<ILoggerPlugin>();
            _plugin.Configure(_moduleAssemblies, out pluginInspector);
        }

        public Logger GetInstance()
        {
            return new Logger(_plugin.GetInstance()); ;
        }
    }
}

