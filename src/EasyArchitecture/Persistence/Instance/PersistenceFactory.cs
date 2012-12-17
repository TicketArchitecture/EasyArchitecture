using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;

namespace EasyArchitecture.Persistence.Instance
{
    internal class PersistenceFactory : IProviderFactory<Persistence>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private IPersistencePlugin _plugin;

        public PersistenceFactory(ModuleAssemblies moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration config)
        {
            _plugin = config.GetPlugin<IPersistencePlugin>();
            _plugin.Configure(_moduleAssemblies);
        }

        public Persistence GetInstance()
        {
            return new Persistence(_plugin.GetInstance()); ;
        }
    }
}

