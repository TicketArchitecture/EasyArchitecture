using System;
using System.Collections.Generic;

namespace EasyArchitecture.Plugins.BuiltIn.Storage
{
    public class StoragePlugin : IStoragePlugin
    {
        private Dictionary<Guid,byte[]> storageInMemory = new Dictionary<Guid,byte[]>();
        public Guid Save(byte[] buffer)
        {
            var id = Guid.NewGuid();
            storageInMemory.Add(id,buffer);
            return id;
        }
    }
}