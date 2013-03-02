using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class StoragePlugin : AbstractPlugin,IStoragePlugin
    {
        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
        }

        public IStorage GetInstance()
        {
            return new Storage();
        }
    }
}