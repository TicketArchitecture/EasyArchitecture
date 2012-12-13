using System;

namespace EasyArchitecture.Plugins
{
    public interface IIoCPlugin
    {
        void Register<T, TU>() where TU : T;
        T Resolve<T>();
        void Register(Type interfaceType, Type implementationType, bool useInterception);
    }
}