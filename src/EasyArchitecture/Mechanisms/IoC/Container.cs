using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.IoC
{
    public static class Container
    {
        public static void Register<T, T1>() where T1 : T
        {
            CreateContext<T>();
            InstanceProvider.GetInstance<Instances.IoC.Container>().Register<T, T1>();
        }

        public static T Resolve<T>()
        {
            CreateContext<T>();
            return InstanceProvider.GetInstance<Instances.IoC.Container>().Resolve<T>();
        }

        private static void CreateContext<T>()
        {
            var moduleName = AssemblyManager.RemoveAssemblySufix(typeof (T).Assembly.GetName().Name);
            LocalThreadStorage.CreateContext(moduleName);
        }
    }
}