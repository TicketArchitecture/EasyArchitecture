using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class MemoryStoragePlugin : Plugin,IStoragePlugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
        }

        public IStorage GetInstance()
        {
            return new MemoryStorage();
        }
    }
}