using System;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.IoC;
using Ninject;

namespace EasyArchitecture.Plugins.Ninject
{
    public class NinjectPlugin : Plugin, IContainerPlugin
    {
        private IKernel _container;

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            _container = new StandardKernel();
        }

        public IContainer GetInstance()
        {
            return new NinjectContainer(_container);
        }
    }
}
