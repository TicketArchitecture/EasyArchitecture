using EasyArchitecture.Runtime.Contracts;

namespace EasyArchitecture.Configuration.Instance
{
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