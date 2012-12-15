using System;

namespace EasyArchitecture.IoC.Plugin.Contracts
{
    //TODO: separae em ServiceLocatorPlugin(Resolve) e ContainerPlugin(Register)
    public interface IIoCPlugin
    {
        void Register<T, TU>() where TU : T;
        T Resolve<T>();
        void Register(Type interfaceType, Type implementationType, bool useInterception);
    }
}