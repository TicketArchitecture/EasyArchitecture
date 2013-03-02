using EasyArchitecture.Core;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Mechanisms.IoC
{
    public static class Container
    {
        public static void Register<T, T1>() where T1 : T
        {
            InstanceProvider.GetInstance<Instances.IoC.Container>().Register<T, T1>();
        }

        public static T Resolve<T>()
        {
            return InstanceProvider.GetInstance<Instances.IoC.Container>().Resolve<T>();
        }
    }
}