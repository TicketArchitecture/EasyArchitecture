using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;

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

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<ICachePlugin>();
            _plugin.Configure(_moduleAssemblies);
        }

        public Cache GetInstance()
        {
            return new Cache(_plugin.GetInstance()); ;
        }
    }
}

