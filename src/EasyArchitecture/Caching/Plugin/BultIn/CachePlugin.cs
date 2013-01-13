using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Caching.Plugin.BultIn
{
    internal class CachePlugin :AbstractPlugin,ICachePlugin
    {
        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
        }

        public ICache GetInstance()
        {
            return new Cache();
        }
    }
}
