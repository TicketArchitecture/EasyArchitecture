using System.Configuration;

namespace EasyArchitecture.Configuration
{
        public class BusinessModuleConfigurationCollection : ConfigurationElementCollection
        {

            public BusinessModuleConfigurationCollection()
            {
                AddElementName = "add";
            }

            protected override ConfigurationElement CreateNewElement()
            {
                return new BusinessModuleConfigurationElement();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((BusinessModuleConfigurationElement)element).Name;
            }

            public BusinessModuleConfigurationElement Get(int index)
            {
                return (BusinessModuleConfigurationElement)BaseGet(index);
            }
        }
    }
