using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class StoragePlugin : Plugin,IStoragePlugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
        }

        public IStorage GetInstance()
        {
            return new Storage();
        }
    }
}