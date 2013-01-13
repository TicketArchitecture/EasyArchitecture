using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Runtime.Plugin;

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

        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            _plugin = pluginConfiguration.GetPlugin<IPersistencePlugin>();
            _plugin.Configure(_moduleAssemblies, out pluginInspector);
        }

        public Persistence GetInstance()
        {
            return new Persistence(_plugin.GetInstance()); ;
        }
    }
}

