using EasyArchitecture.Core;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Instances.Log
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

