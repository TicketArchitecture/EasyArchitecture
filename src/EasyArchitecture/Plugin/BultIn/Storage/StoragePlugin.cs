using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.Contracts.Storage;

namespace EasyArchitecture.Plugin.BultIn.Storage
{
    internal class StoragePlugin : AbstractPlugin,IStoragePlugin
    {
        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
        }

        public IStorage GetInstance()
        {
            return new EasyArchitecture.Plugin.BultIn.Storage.Storage();
        }
    }
}