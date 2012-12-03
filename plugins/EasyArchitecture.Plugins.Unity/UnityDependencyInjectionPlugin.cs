using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class UnityDependencyInjectionPlugin:IDependencyInjectionPlugin
    {
        private readonly IUnityContainer _container;

        public UnityDependencyInjectionPlugin()
        {
            if (_container != null) return;

            _container = new UnityContainer();
            _container.AddNewExtension<Interception>();

            ConfigurePoliceInterceptor();
        }

        public void Register<T, T1>() where T1 : T
        {
            _container.RegisterType<T, T1>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Register(Type interfaceType, Type implementationType, bool useInterception)
        {
            if (useInterception)
            {
                _container.RegisterType(
                    interfaceType, implementationType,
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<InterfaceInterceptor>());
            }
            else
            {
                _container.RegisterType(interfaceType, implementationType, null, null);
            }
        }


        private void ConfigurePoliceInterceptor()
        {
            _container.Configure<Interception>()
                .AddPolicy("Context")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(true)))
                .AddCallHandler(typeof(ContextHandler));
            _container.Configure<Interception>()
                .AddPolicy("Loggining")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(true)))
                .AddCallHandler(typeof(LoggingHandler));
            _container.Configure<Interception>()
                .AddPolicy("Transaction")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(false)))
                .AddCallHandler(typeof(TransactionHandler));
        }
    }
}
