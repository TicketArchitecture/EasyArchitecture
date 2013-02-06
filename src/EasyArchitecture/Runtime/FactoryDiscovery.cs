using EasyArchitecture.Configuration.Exceptions;
using EasyArchitecture.Runtime.Contracts;

namespace EasyArchitecture.Runtime
{
    internal static class FactoryDiscovery
    {
        internal static IProviderFactory<T> Discover<T>()
        {
            var moduleName = LocalThreadStorage.GetCurrentModuleName();
            var moduleConfiguration = ModuleConfigurationList.Get(moduleName);

            if (moduleConfiguration==null)
                throw new NotConfiguredModuleException(moduleName);

            return (IProviderFactory<T>) moduleConfiguration.Factories[typeof (T)];
        }
    }
}