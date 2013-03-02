using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Caching;

namespace EasyArchitecture.Plugins.BultIn.Caching
{
    internal class CachePlugin :Plugin,ICachePlugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
        }

        public ICache GetInstance()
        {
            return new Cache();
        }
    }
}
