using System;

namespace EasyArchitecture.Plugin.Contracts.IoC
{
    public interface IContainer
    {
        void Register<T, TU>() where TU : T;
        void Register(Type interfaceType, Type implementationType, bool useInterception);
        T Resolve<T>();
    }
}