using EasyArchitecture.Plugins.Contracts.Storage;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace EasyArchitecture.Plugins.Azure
{
    public class AzureBlobStoragePlugin : Plugin, IStoragePlugin
    {
        private CloudBlobClient _blobClient;

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public IStorage GetInstance()
        {
            return new AzureBlobStorage(_blobClient);
        }
    }
}
