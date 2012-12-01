using System;
using System.Collections.Concurrent;

namespace EasyArchitecture.Internal
{
    internal static class EasyConfigurations
    {
        internal static readonly ConcurrentDictionary<string, EasyConfig> Configurations = new ConcurrentDictionary<string, EasyConfig>();

        internal static EasyConfig Selector<T>()
        {
            return Selector(AssemblyManager.ModuleName<T>());
        }

        internal static EasyConfig SelectorByThread()
        {
            return Selector(LocalThreadStorage.GetCurrentBusinessModuleName());
        }

        private static EasyConfig Selector(string moduleName)
        {
            EasyConfig instance;

            if (!EasyConfigurations.Configurations.TryGetValue(moduleName, out instance))
                throw new Exception("NotConfigured");

            return instance;
        }
    }
}
