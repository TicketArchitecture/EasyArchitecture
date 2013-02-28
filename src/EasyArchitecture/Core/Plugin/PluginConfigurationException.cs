using System;

namespace EasyArchitecture.Core.Plugin
{
    public class PluginConfigurationException : Exception
    {
        public PluginConfigurationException(string getPluginConfigurationInfo, Exception exception):base(getPluginConfigurationInfo,exception)
        {
            
        }
    }
}