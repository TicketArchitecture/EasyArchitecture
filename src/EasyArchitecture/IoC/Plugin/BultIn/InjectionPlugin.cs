using System;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class IocPlugin : IIoCPlugin
    {
        public void Register<T, T1>() where T1 : T
        {
            Container.Register<T,T1>();
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public void Register(Type interfaceType, Type implementationType, bool useInterception)
        {
            Container.RegisterType(interfaceType,implementationType);
        }
    }
}
