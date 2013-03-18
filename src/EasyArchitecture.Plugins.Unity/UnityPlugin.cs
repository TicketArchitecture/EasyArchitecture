using System;
using EasyArchitecture.Plugins.Contracts.IoC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{

    public class UnityPlugin : AbstractContainerPlugin, IContainerPlugin
    {
        private IUnityContainer _container;

        public IContainer GetInstance()
        {
            return new UnityContainer(_container);
        }

        protected override void ConfigureContainerPlugin(PluginInspector pluginInspector)
        {
            _container = new Microsoft.Practices.Unity.UnityContainer();
            _container.AddNewExtension<Interception>();
            _container.Configure<Interception>().AddPolicy("general")
                .AddMatchingRule<AnyMatchingRule>()
                .AddCallHandler<InterceptionHandler>();
        }

        protected override void Register(Type interfaceType, Type concreteType, PluginInspector pluginInspector)
        {
            _container.RegisterType(interfaceType, concreteType);
        }

        protected override void RegisterWithInterception(Type interfaceType, Type concreteType,
                                                         PluginInspector pluginInspector)
        {
            //_container.RegisterType(interfaceType, concreteType, new Interceptor<InterfaceInterceptor>());
            _container.RegisterType(interfaceType, concreteType);
            _container.Configure<Interception>().SetInterceptorFor(interfaceType, new InterfaceInterceptor());
        }
    }
}

