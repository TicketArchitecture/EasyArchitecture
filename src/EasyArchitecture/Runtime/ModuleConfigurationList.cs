using System.Collections.Generic;

namespace EasyArchitecture.Runtime
{
    public static class ModuleConfigurationList
    {
        private static readonly Dictionary<string, ModuleConfiguration> List = new Dictionary<string, ModuleConfiguration>();

        public static void Add(string moduleName, ModuleConfiguration moduleConfiguration)
        {
            if (List.ContainsKey(moduleName))
            {
                List[moduleName] = moduleConfiguration;
            }
            else
            {
                List.Add(moduleName, moduleConfiguration);    
            }
        }

        public static ModuleConfiguration Get(string moduleName)
        {
            return List.ContainsKey(moduleName) ? List[moduleName] : null;
        }
    }
}