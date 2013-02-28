using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.Contracts.Caching;

namespace EasyArchitecture.Plugin.BultIn.Caching
{
    internal class CachePlugin :AbstractPlugin,ICachePlugin
    {
        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
        }

        public ICache GetInstance()
        {
            return new EasyArchitecture.Plugin.BultIn.Caching.Cache();
        }
    }
}
