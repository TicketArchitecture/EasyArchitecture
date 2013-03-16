using System;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.IoC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{

    public class UnityPlugin : AbstractContainerPlugin, IContainerPlugin
    {
        private IUnityContainer _container;

        //private void ConfigurePoliceInterceptor()
        //{
        //    _container.Configure<Interception>()
        //        .AddPolicy("Interception")
        //        .AddMatchingRule<FacadeMatchingRule>()
        //        .AddCallHandler(typeof(InterceptionHandler));
        //}

        public IContainer GetInstance()
        {
            return new UnityContainer(_container);
        }


        protected override void ConfigureContainerPlugin(PluginInspector pluginInspector)
        {
            if (_container != null) return;

            _container = new Microsoft.Practices.Unity.UnityContainer();
            _container.AddNewExtension<Interception>();

            //ConfigurePoliceInterceptor();
        }

        protected override void Register(Type interfaceType, Type concreteType, PluginInspector pluginInspector)
        {
            _container.RegisterType(interfaceType, concreteType, null,null,null);
        }

        protected override void RegisterWithInterception(Type interfaceType, Type concreteType, PluginInspector pluginInspector)
        {
            //TODO: configurar interception handler
            _container.RegisterType(interfaceType, concreteType, null, null, null);
        }
    }


    //public class UnityPlugin : Plugin,IContainerPlugin
    //{
    //    private IUnityContainer _container;

    //    private void ConfigurePoliceInterceptor()
    //    {
    //        _container.Configure<Interception>()
    //            .AddPolicy("Interception")
    //            .AddMatchingRule<FacadeMatchingRule>()
    //            .AddCallHandler(typeof(InterceptionHandler));
    //    }

    //    public IContainer GetInstance()
    //    {
    //        return new UnityContainer(_container);
    //    }

    //    protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
    //    {
    //           if (_container != null) return;

    //        _container = new Microsoft.Practices.Unity.UnityContainer();
    //        _container.AddNewExtension<Interception>();

    //        ConfigurePoliceInterceptor();
    //    }        
    //}
}
