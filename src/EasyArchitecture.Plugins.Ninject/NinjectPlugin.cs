using System;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.IoC;
using Ninject;

namespace EasyArchitecture.Plugins.Ninject
{
    public class NinjectPlugin : AbstractPlugin, IContainerPlugin
    {
        private IKernel _container;

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            _container = new StandardKernel();
        }

        public IContainer GetInstance()
        {
            return new NinjectContainer(_container);
        }
    }
}
