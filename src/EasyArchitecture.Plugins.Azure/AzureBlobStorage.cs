using System.Collections.Generic;
using System.IO;
using System.Linq;
using EasyArchitecture.Plugins.Contracts.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace EasyArchitecture.Plugins.Azure
{
    public class AzureBlobStorage:IStorage
    {
        private readonly CloudBlobClient _blobClient;

        public AzureBlobStorage(CloudBlobClient blobClient)
        {
            _blobClient = blobClient;
        }

        private CloudBlobContainer CloudBlobContainer(string container)
        {
            var blobContainer = _blobClient.GetContainerReference(container);
            blobContainer.CreateIfNotExists();
            return blobContainer;
        }

        public bool Exists(string container, string identifier)
        {
            return CloudBlobContainer(container).GetBlockBlobReference(identifier).Exists();
        }

        public void Save(Stream stream, string container, string identifier)
        {
            CloudBlobContainer(container).GetBlockBlobReference(identifier).UploadFromStream(stream);
        }

        public IEnumerable<string> List(string container)
        {
            return CloudBlobContainer(container).ListBlobs(null, false).OfType<CloudBlockBlob>().Select(blob => blob.Uri.Segments.LastOrDefault()).ToList();
        }

        public void Retrieve(Stream stream, string container, string identifier)
        {
            CloudBlobContainer(container).GetBlockBlobReference(identifier).DownloadToStream(stream);
            stream.Position = 0;
        }

        public void Delete(string container, string identifier)
        {
            CloudBlobContainer(container).GetBlockBlobReference(identifier).Delete();
        }
    }
}

