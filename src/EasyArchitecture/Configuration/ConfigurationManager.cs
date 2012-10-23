using System;
using System.Collections.Generic;
using EasyArchitecture.Diagnostic;

namespace EasyArchitecture.Configuration
{
    internal static class ConfigurationManager
    {
        private static readonly List<BusinessModuleConfig> BusinessModuleConfigs = new List<BusinessModuleConfig>();

        internal static IEnumerable<BusinessModuleConfig> GetBusinessModulesConfiguration()
        {
            BusinessModuleConfigs.Clear();

            var easyConfigSection = GetEasyConfigSection();

            for (var count = 0; count < easyConfigSection.BusinessModules.Count; count++)
            {
                var businessModuleConfiguration = easyConfigSection.BusinessModules.Get(count);

                var businessModuleConfig = new BusinessModuleConfig
                              {
                                  Name = businessModuleConfiguration.Name,
                                  LogLevel = businessModuleConfiguration.LogLevel,
                                  ConnectionString = businessModuleConfiguration.ConnectionString
                              };

                BusinessModuleConfigs.Add(businessModuleConfig);

                Log.To(typeof (ConfigurationManager)).Message("Found configuration for [{0}] business module",businessModuleConfiguration.Name).Debug();
            }

            return BusinessModuleConfigs;
        }

        private static EasyConfigSection GetEasyConfigSection()
        {
            var easyConfigSection = System.Configuration.ConfigurationManager.GetSection("easyConfig") as EasyConfigSection;

            if (easyConfigSection == null)
                throw new Exception("easyConfig section doesnt exists!");

            return easyConfigSection;
        }

        internal static string GetLogLevel()
        {
            var easyConfigSection = GetEasyConfigSection();

            return easyConfigSection.LogLevel;
        }

    }
}
