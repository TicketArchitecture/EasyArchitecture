using EasyArchitecture.Core;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.Caching;

namespace EasyArchitecture.Instances.Caching
{
    internal class CacheFactory : IProviderFactory<Instances.Caching.Cache>, IConfigurableFactory
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

        public Instances.Caching.Cache GetInstance()
        {
            return new Instances.Caching.Cache(_plugin.GetInstance()); ;
        }
    }
}

