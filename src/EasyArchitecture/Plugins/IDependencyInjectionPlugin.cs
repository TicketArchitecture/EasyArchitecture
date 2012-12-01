using System;

namespace EasyArchitecture.Plugins
{
    public interface IDependencyInjectionPlugin
    {
        void Register<T, T1>() where T1 : T;
        T GetInstance<T>();
        void RegisterType(Type interfaceType, Type implementationType, bool useInterception);
    }
}