using System;

namespace EasyArchitecture.IoC.Plugin.Contracts
{
    public interface IContainer
    {
        void Register<T, TU>() where TU : T;
        void Register(Type interfaceType, Type implementationType, bool useInterception);
        T Resolve<T>();
    }
}