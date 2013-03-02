using System;

namespace EasyArchitecture.Plugins
{
    public abstract class AbstractPlugin : IConfigurablePlugin
    {
        public void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector)
        {
            pluginInspector = new PluginInspector(this);
            try
            {
                ConfigurePlugin(pluginConfiguration, pluginInspector);
            }
            catch (Exception exception)
            {
                throw new PluginConfigurationException(pluginInspector.ExtractInfo(),exception);
            }
        }

        protected abstract void ConfigurePlugin(PluginConfiguration pluginConfiguration,  PluginInspector pluginInspector);
    }
}