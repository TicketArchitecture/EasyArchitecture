using Autofac;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.Contracts.IoC;

namespace EasyArchitecture.Plugins.Autofac
{
    public class AutofacPlugin : AbstractPlugin, IContainerPlugin
    {
        private global::Autofac.IContainer _container;

        public Plugin.Contracts.IoC.IContainer GetInstance()
        {
            return new AutofacContainer(_container);
        }

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            if (_container != null) return;

            var builder = new ContainerBuilder();
            
            //TODO:loop
            //builder.RegisterType<string>();
            
            _container = builder.Build();
        }
    }
}
