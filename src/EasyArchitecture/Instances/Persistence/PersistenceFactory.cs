using EasyArchitecture.Core;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.Persistence;

namespace EasyArchitecture.Instances.Persistence
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

