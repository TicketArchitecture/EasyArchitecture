﻿using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.Contracts.IoC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class UnityPlugin : AbstractPlugin,IContainerPlugin
    {
        private IUnityContainer _container;

        private void ConfigurePoliceInterceptor()
        {
            _container.Configure<Interception>()
                .AddPolicy("Interception")
                .AddMatchingRule<FacadeMatchingRule>()
                .AddCallHandler(typeof(InterceptionHandler));
        }

        public IContainer GetInstance()
        {
            return new UnityContainer(_container);
        }

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
               if (_container != null) return;

            _container = new Microsoft.Practices.Unity.UnityContainer();
            _container.AddNewExtension<Interception>();

            ConfigurePoliceInterceptor();
        }        
    }
}