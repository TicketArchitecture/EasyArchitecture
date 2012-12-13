using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.IoC.Mechanism
{
    public static class ServiceLocator 
    {
        public static T Resolve<T>()
        {
            //return EasyConfigurations.Selector<T>().DependencyInjection.Resolve<T>();
            return EasyConfigurations.SelectorByThread().ServiceLocator.Resolve<T>();
        }

        public static void Register<T, T1>() where T1 : T
        {
            //EasyConfigurations.Selector<T>().DependencyInjection.Register<T, T1>();
            EasyConfigurations.SelectorByThread().ServiceLocator.Register<T, T1>();
        }
    }
}
