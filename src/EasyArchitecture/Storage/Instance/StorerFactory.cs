using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Instance
{
    internal class StorerFactory : IProviderFactory<Storer>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _easyCofig;
        private IStoragePlugin _plugin;

        public StorerFactory(ModuleAssemblies easyCofig)
        {
            _easyCofig = easyCofig;
        }

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<IStoragePlugin>();
            _plugin.Configure(_easyCofig.InfrastructureAssembly);
        }

        public Storer GetInstance()
        {
            return new Storer(_plugin.GetInstance()); ;
        }
    }
}

