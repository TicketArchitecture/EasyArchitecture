using EasyArchitecture.Runtime;

namespace EasyArchitecture.IoC
{
    public static class Container
    {
        public static void Register<T, T1>() where T1 : T
        {
            InstanceProvider.GetInstance<Instance.Container>().Register<T, T1>();
        }
        public static T Resolve<T>()
        {
            return InstanceProvider.GetInstance<Instance.Container>().Resolve<T>();
        }

    }
}