using System;

namespace EasyArchitecture.Plugins
{
    public class PluginConfigurationException : Exception
    {
        public PluginConfigurationException(string getPluginConfigurationInfo, Exception exception):base(getPluginConfigurationInfo,exception)
        {
            
        }
    }
}