using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public static class DependencyInjection 
    {
        public static T Resolve<T>()
        {
            return EasyConfigurations.Selector<T>().DependencyInjection.Resolve<T>();
        }

        public static void Register<T, T1>() where T1 : T
        {
            EasyConfigurations.Selector<T>().DependencyInjection.Register<T, T1>();
        }
    }
}
