using System;
using System.Collections.Generic;

namespace EasyArchitecture.Plugins
{
    public abstract class Plugin : IConfigurablePlugin
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
                throw new PluginConfigurationException(new PluginInspectorExtrator(new List<PluginInspector> {pluginInspector}).ToString(), exception);
            }
        }

        protected abstract void ConfigurePlugin(PluginConfiguration pluginConfiguration,  PluginInspector pluginInspector);
    }
}