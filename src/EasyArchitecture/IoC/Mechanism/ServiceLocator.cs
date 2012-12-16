using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.IoC.Mechanism
{
    public static class ServiceLocator 
    {
        public static T Resolve<T>()
        {
            return ConfigurationSelector.Selector().ServiceLocator.Resolve<T>();
        }

        public static void Register<T, T1>() where T1 : T
        {
            ConfigurationSelector.Selector().ServiceLocator.Register<T, T1>();
        }
    }
}
