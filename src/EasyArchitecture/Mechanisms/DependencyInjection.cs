using EasyArchitecture.Initialization;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class DependencyInjection 
    {
        public static T Resolve<T>()
        {
            //discovery instance
            var moduleName = AssemblyManager.ModuleName<T>();
            //execute
            return EasyConfigurations.Configurations[moduleName].DependencyInjection.Resolve<T>();
        }

        public static void Register<T, T1>() where T1 : T
        {
            //discovery instance
            var moduleName = AssemblyManager.ModuleName<T>();
            //execute
            EasyConfigurations.Configurations[moduleName].DependencyInjection.Register<T, T1>();
        }
    }
}
