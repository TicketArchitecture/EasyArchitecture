using System.Collections.Concurrent;
using EasyArchitecture.Configuration.Exceptions;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Configuration.Instance
{
    internal static class EasyConfigurations
    {
        internal static readonly ConcurrentDictionary<string, EasyConfig> Configurations = new ConcurrentDictionary<string, EasyConfig>();

        //internal static EasyConfig Selector<T>()
        //{
        //    var type = typeof (T);
        //    if(type.IsGenericType)
        //        type= type.GetGenericArguments().FirstOrDefault();

        //    return Selector(AssemblyManager.ModuleName(type));
        //}

        internal static EasyConfig SelectorByThread()
        {
            return Selector(LocalThreadStorage.GetCurrentModuleName());
        }

        private static EasyConfig Selector(string moduleName)
        {
            EasyConfig instance;

            if (!EasyConfigurations.Configurations.TryGetValue(moduleName, out instance))
                throw new NotConfiguredModuleException(moduleName);

            return instance;
        }
    }
}
