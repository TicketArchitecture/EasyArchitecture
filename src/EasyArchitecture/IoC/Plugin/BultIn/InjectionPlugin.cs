using System;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class IocPlugin : IIoCPlugin
    {
        private readonly Container _container = new Container();

        public void Register<T, T1>() where T1 : T
        {
            //container.Register<T,T1>();
            _container.RegisterType(typeof(T), typeof(T1));
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Register(Type interfaceType, Type implementationType, bool useInterception)
        {
            _container.RegisterType(interfaceType,implementationType);
        }
    }
}
