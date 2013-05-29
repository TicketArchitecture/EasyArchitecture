using System;
using System.Collections.Generic;
using System.IO;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class Storage : IStorage
    {
        private readonly Dictionary<string, byte[]> _storageInMemory = new Dictionary<string, byte[]>();

        public void Save(Stream stream, string identifier)
        {
            var length = (int)stream.Length;
            var buffer = new byte[length];

            stream.Write(buffer, 0, (int)stream.Length);
            
            _storageInMemory.Add(identifier, buffer);
        }

        //TODO: trocar para IEnumerable
        public List<string> List()
        {
            return new List<string>(_storageInMemory.Keys);
        }

        public void Retrieve(Stream stream, string identifier)
        {
            //using (var reader = new BinaryReader(stream))
            //{
            //    _storageInMemory.Add(identifier, reader.ReadBytes((int)reader.BaseStream.Length));
            //}

            var buffer = _storageInMemory[identifier];
            stream.Read(buffer, 0, (int)stream.Length);

            
        }

        public void Delete(string identifier)
        {
            _storageInMemory.Remove(identifier);
        }

        public bool Exists(string identifier)
        {
            return _storageInMemory.ContainsKey(identifier);
        }
    }
}