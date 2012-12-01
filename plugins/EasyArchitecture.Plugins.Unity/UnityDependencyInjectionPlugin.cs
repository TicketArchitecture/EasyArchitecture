using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class UnityDependencyInjectionPlugin:IDependencyInjectionPlugin
    {
        private IUnityContainer Container;

        public UnityDependencyInjectionPlugin()
        {
            if (Container != null) return;

            Container = new UnityContainer();
            Container.AddNewExtension<Interception>();

            ConfigurePoliceInterceptor();
        }

        public void Register<T, T1>() where T1 : T
        {
            Container.RegisterType<T, T1>();
        }

        public T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public void RegisterType(Type interfaceType, Type implementationType, bool useInterception)
        {
            if (useInterception)
            {
                Container.RegisterType(
                    interfaceType, implementationType,
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<VirtualMethodInterceptor>());


            }
            else
            {
                Container.RegisterType(interfaceType, implementationType, null, null);
            }
        }


        private void ConfigurePoliceInterceptor()
        {
            Container.Configure<Interception>()
                .AddPolicy("Context")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(true)))
                .AddCallHandler(typeof(ContextHandler));
            Container.Configure<Interception>()
                .AddPolicy("Loggining")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(true)))
                .AddCallHandler(typeof(LoggingHandler));
            Container.Configure<Interception>()
                .AddPolicy("Transaction")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(false)))
                .AddCallHandler(typeof(TransactionHandler));
        }
    }
}
