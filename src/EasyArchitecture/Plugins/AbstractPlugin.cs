using System;
using EasyArchitecture.Core;

namespace EasyArchitecture.Plugins
{
    public abstract class AbstractPlugin : IConfigurablePlugin
    {
        public void Configure(ModuleAssemblies moduleAssemblies, out PluginInspector pluginInspector)
        {
            pluginInspector = new PluginInspector(this);
            try
            {
                ConfigurePlugin(moduleAssemblies, pluginInspector);
            }
            catch (Exception exception)
            {
                throw new PluginConfigurationException(pluginInspector.ExtractInfo(),exception);
            }
        }

        protected abstract void ConfigurePlugin(ModuleAssemblies moduleAssemblies,  PluginInspector pluginInspector);
    }
}