using System;
using System.Collections.Concurrent;
using EasyArchitecture.Initialization;

namespace EasyArchitecture.Internal
{
    internal static class EasyConfigurations
    {
        internal static readonly ConcurrentDictionary<string,EasyConfig> Configurations = new ConcurrentDictionary<string, EasyConfig>();

        internal static EasyConfig Selector<T>()
        {
            var moduleName = AssemblyManager.ModuleName<T>();
            EasyConfig instance;

            if(!EasyConfigurations.Configurations.TryGetValue(moduleName, out instance))
                throw new Exception("NotConfigured");

            return instance;
        }
    }
}
