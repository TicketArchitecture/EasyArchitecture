using System;
using EasyArchitecture.Plugins.Contracts.IoC;
using Ninject;

namespace EasyArchitecture.Plugins.Ninject
{
    public class NinjectContainer : IContainer
    {
        private readonly IKernel _container;

        public NinjectContainer(IKernel ninjectKernel)
        {
            _container = ninjectKernel;
        }

        public void Register<T, TU>() where TU : T
        {
            _container.Bind<T>().To<TU>();
        }

        public void Register(Type interfaceType, Type implementationType)
        {
            _container.Bind(interfaceType, implementationType);
        }

        public T Resolve<T>()
        {
            return _container.Get<T>();
        }
    }
}
