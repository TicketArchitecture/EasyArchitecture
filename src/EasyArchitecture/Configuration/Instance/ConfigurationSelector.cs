using System.Collections.Concurrent;
using EasyArchitecture.Configuration.Exceptions;
using EasyArchitecture.Runtime;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Configuration.Instance
{
    internal static class ConfigurationSelector
    {
        internal static readonly ConcurrentDictionary<string, ModuleConfiguration> Configurations = new ConcurrentDictionary<string, ModuleConfiguration>();

        internal static ModuleConfiguration Selector()
        {
            var moduleName = LocalThreadStorage.GetCurrentModuleName();
            ModuleConfiguration instance;

            if (!ConfigurationSelector.Configurations.TryGetValue(moduleName, out instance))
                throw new NotConfiguredModuleException(moduleName);

            return instance;

        }
    }

    internal static class FactoryDiscovery
    {
        //internal static readonly ConcurrentDictionary<string, ModuleConfiguration> Configurations = new ConcurrentDictionary<string, ModuleConfiguration>();

        internal static IProviderFactory<T> Discover<T>()
        {
            //var moduleName = LocalThreadStorage.GetCurrentModuleName();
            //ModuleConfiguration instance;

            //if (!ConfigurationSelector.Configurations.TryGetValue(moduleName, out instance))
            //    throw new NotConfiguredModuleException(moduleName);

            //return instance;
            return default(IProviderFactory<T>) ;
        }
    }

}
