using System.Reflection;
using EasyArchitecture.Plugins.Tests.Storage;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Azure.Tests
{
    [Ignore("Necessita do Azure Storage Emulator - Marcado para ser ignorado pelo build automático")]
    public class StorageTest:MinimalStorageTest
    {
        public override void SetUp()
        {
            var plugin = new AzureBlobStoragePlugin();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            Storage = plugin.GetInstance();

        }
    }
}
