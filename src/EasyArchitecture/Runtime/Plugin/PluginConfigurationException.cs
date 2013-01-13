using System;

namespace EasyArchitecture.Runtime.Plugin
{
    public class PluginConfigurationException : Exception
    {
        public PluginConfigurationException(string getPluginConfigurationInfo, Exception exception):base(getPluginConfigurationInfo,exception)
        {
            
        }
    }
}