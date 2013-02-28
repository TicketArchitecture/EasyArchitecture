using EasyArchitecture.Core;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.IoC;

namespace EasyArchitecture.Instances.IoC
{
    internal class ContainerFactory : IProviderFactory<Instances.IoC.Container>, IConfigurableFactory
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

        public Instances.IoC.Container GetInstance()
        {
            return new Instances.IoC.Container(_plugin.GetInstance()); ;
        }
    }
}

