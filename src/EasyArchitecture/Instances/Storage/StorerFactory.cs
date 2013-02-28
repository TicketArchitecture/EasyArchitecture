using EasyArchitecture.Core;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.Storage;

namespace EasyArchitecture.Instances.Storage
{
    internal class StorerFactory : IProviderFactory<Storer>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private IStoragePlugin _plugin;

        public StorerFactory(ModuleAssemblies moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            _plugin = pluginConfiguration.GetPlugin<IStoragePlugin>();
            _plugin.Configure(_moduleAssemblies, out pluginInspector);
        }

        public Storer GetInstance()
        {
            return new Storer(_plugin.GetInstance()); ;
        }
    }
}

