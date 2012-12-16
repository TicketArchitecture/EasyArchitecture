using System;
using System.Collections.Generic;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Plugin.BultIn
{
    internal class Storage : IStorage
    {
        private readonly Dictionary<Guid,byte[]> _storageInMemory = new Dictionary<Guid,byte[]>();

        public Guid Save(byte[] buffer)
        {
            var id = Guid.NewGuid();
            _storageInMemory.Add(id,buffer);
            return id;
        }

        public byte[] Get(Guid id)
        {
            return _storageInMemory[id];
        }

        public bool Exists(Guid id)
        {
            return _storageInMemory.ContainsKey(id);
        }
    }
}