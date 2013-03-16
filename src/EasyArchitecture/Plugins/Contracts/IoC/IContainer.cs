using System;

namespace EasyArchitecture.Plugins.Contracts.IoC
{
    public interface IContainer
    {
        void Register<T, TU>() where TU : T;
        void Register(Type interfaceType, Type implementationType, bool useInterception);
        T Resolve<T>();
        object Resolve(Type interfaceType);
    }
}