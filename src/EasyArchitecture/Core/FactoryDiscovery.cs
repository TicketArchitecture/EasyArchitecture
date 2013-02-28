using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Mechanisms.Configuration.Exceptions;

namespace EasyArchitecture.Core
{
    internal static class FactoryDiscovery
    {
        internal static IProviderFactory<T> Discover<T>()
        {
            var moduleName = LocalThreadStorage.GetCurrentContext().Name;
            var moduleConfiguration = ModuleConfigurationList.Get(moduleName);

            if (moduleConfiguration==null)
                throw new NotConfiguredModuleException(moduleName);

            return (IProviderFactory<T>) moduleConfiguration.Factories[typeof (T)];
        }
    }
}