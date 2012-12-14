using System.Collections.Concurrent;
using EasyArchitecture.Configuration.Exceptions;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Configuration.Instance
{
    internal static class ConfigurationSelector
    {
        internal static readonly ConcurrentDictionary<string, ModuleConfiguration> Configurations = new ConcurrentDictionary<string, ModuleConfiguration>();

        //internal static EasyConfig Selector<T>()
        //{
        //    var type = typeof (T);
        //    if(type.IsGenericType)
        //        type= type.GetGenericArguments().FirstOrDefault();

        //    return Selector(AssemblyManager.ModuleName(type));
        //}

        internal static ModuleConfiguration SelectorByThread()
        {
            return Selector(LocalThreadStorage.GetCurrentModuleName());
        }

        private static ModuleConfiguration Selector(string moduleName)
        {
            ModuleConfiguration instance;

            if (!ConfigurationSelector.Configurations.TryGetValue(moduleName, out instance))
                throw new NotConfiguredModuleException(moduleName);

            return instance;
        }
    }
}
