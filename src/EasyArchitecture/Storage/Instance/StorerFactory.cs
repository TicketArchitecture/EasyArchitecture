using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Instance
{
    internal class StorerFactory : IProviderFactory<Storer>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private IStoragePlugin _plugin;

        public StorerFactory(ModuleAssemblies moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<IStoragePlugin>();
            _plugin.Configure(_moduleAssemblies);
        }

        public Storer GetInstance()
        {
            return new Storer(_plugin.GetInstance()); ;
        }
    }
}

