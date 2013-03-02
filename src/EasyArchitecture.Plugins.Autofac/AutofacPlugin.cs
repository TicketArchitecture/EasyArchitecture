using Autofac;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.IoC;
using IContainer = EasyArchitecture.Plugins.Contracts.IoC.IContainer;

namespace EasyArchitecture.Plugins.Autofac
{
    public class AutofacPlugin : Plugin, IContainerPlugin
    {
        private global::Autofac.IContainer _container;

        public IContainer GetInstance()
        {
            return new AutofacContainer(_container);
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            if (_container != null) return;

            var builder = new ContainerBuilder();

            _container = builder.Build();
        }
    }
}
