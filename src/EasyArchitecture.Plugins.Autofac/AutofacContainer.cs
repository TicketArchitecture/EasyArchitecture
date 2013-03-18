using System;
using Autofac;

namespace EasyArchitecture.Plugins.Autofac
{
    public class AutofacContainer : Contracts.IoC.IContainer
    {
        private readonly global::Autofac.IContainer _container;

        public AutofacContainer(IContainer container)
        {
            _container = container;
        }

        public void Register<T, T1>() where T1 : T
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.RegisterType<T1>().As<T>();
            newBuilder.Update(_container);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Register(Type interfaceType, Type implementationType)
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.RegisterType(implementationType).As(interfaceType);
            newBuilder.Update(_container);

        }

    }
}
