using System.Configuration;

namespace EasyArchitecture.Configuration
{
        public class EasyConfigSection : ConfigurationSection
        {
            [ConfigurationProperty("businessModules")]
            public BusinessModuleConfigurationCollection BusinessModules
            {
                get
                {
                    return (BusinessModuleConfigurationCollection)this["businessModules"];
                }
            }

            [ConfigurationProperty("logLevel")]
            public string LogLevel
            {
                get
                {
                    return (string)this["logLevel"];
                }
                set
                {
                    this["logLevel"] = value;
                }
            }

        }
}
