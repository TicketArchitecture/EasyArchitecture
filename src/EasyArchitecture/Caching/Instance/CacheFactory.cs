using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Caching.Instance
{
    internal class CacheFactory : IProviderFactory<Cache>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private ICachePlugin _plugin;

        public CacheFactory(ModuleAssemblies moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            _plugin = pluginConfiguration.GetPlugin<ICachePlugin>();
            _plugin.Configure(_moduleAssemblies, out pluginInspector);
        }

        public Cache GetInstance()
        {
            return new Cache(_plugin.GetInstance()); ;
        }
    }
}

