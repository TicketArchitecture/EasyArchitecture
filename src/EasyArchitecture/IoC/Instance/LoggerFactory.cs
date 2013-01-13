using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.IoC.Instance
{
    internal class ContainerFactory : IProviderFactory<Container>, IConfigurableFactory
    {
        private readonly ModuleAssemblies _moduleAssemblies;
        private IContainerPlugin _plugin;

        public ContainerFactory(ModuleAssemblies moduleAssemblies)
        {
            _moduleAssemblies = moduleAssemblies;
        }

        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            _plugin = pluginConfiguration.GetPlugin<IContainerPlugin>();
            _plugin.Configure(_moduleAssemblies, out pluginInspector);
        }

        public Container GetInstance()
        {
            return new Container(_plugin.GetInstance()); ;
        }
    }
}

