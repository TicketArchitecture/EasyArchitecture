using System;
using EasyArchitecture.Plugin.Contracts.IoC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class UnityContainer:IContainer
    {
        private readonly IUnityContainer _container;

        public UnityContainer(IUnityContainer container)
        {
            _container = container;
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

    }
}
