using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime.Contracts;

namespace EasyArchitecture.Caching.Instance
{
    internal class CacheFactory : IProviderFactory<Cache>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _easyCofig;
        private ICachePlugin _plugin;

        public CacheFactory(ModuleAssemblies easyCofig)
        {
            _easyCofig = easyCofig;
        }

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<ICachePlugin>();
            _plugin.Configure(_easyCofig.InfrastructureAssembly);
        }

        public Cache GetInstance()
        {
            return new Cache(_plugin.GetInstance()); ;
        }
    }
}

