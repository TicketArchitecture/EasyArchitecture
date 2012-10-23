using System.Configuration;

namespace EasyArchitecture.Configuration
{
        public class BusinessModuleConfigurationElement : ConfigurationElement
        {
            [ConfigurationProperty("name")]
            public string Name
            {
                get
                {
                    return (string)this["name"];
                }
                set
                {
                    this["name"] = value;
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

            [ConfigurationProperty("connectionString")]
            public string ConnectionString
            {
                get
                {
                    return (string)this["connectionString"];
                }
                set
                {
                    this["connectionString"] = value;
                }
            }
        }
    }

