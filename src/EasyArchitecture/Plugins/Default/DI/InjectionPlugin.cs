using System;

namespace EasyArchitecture.Plugins.Default.DI
{
    public class InjectionPlugin : IDependencyInjectionPlugin
    {
        public void Register<T, T1>() where T1 : T
        {
            Container.Register<T,T1>();
        }

        public T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        //TODO: useInterception
        public void RegisterType(Type interfaceType, Type implementationType, bool useInterception)
        {
            Container.RegisterType(interfaceType,implementationType);
            
        }
    }
}
