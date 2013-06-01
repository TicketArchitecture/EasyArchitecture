using System.Collections.Generic;
using System.IO;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class MemoryStorage : IStorage
    {
        private readonly Dictionary<string, Dictionary<string, byte[]>> _containers = new Dictionary<string, Dictionary<string, byte[]>>();

        public void Save(Stream stream, string container, string identifier)
        {
            var buffer = new byte[stream.Length];

            stream.Read(buffer, 0, (int)stream.Length);
  
            ContainerExistenceAssurance(container);
            _containers[container].Add(identifier, buffer);
        }

        private void ContainerExistenceAssurance(string container)
        {
            if (!_containers.ContainsKey(container))
                _containers.Add(container,new Dictionary<string, byte[]>());
        }

        public IEnumerable<string> List(string container)
        {
            ContainerExistenceAssurance(container);
            return new List<string>(_containers[container].Keys);
        }

        public void Retrieve(Stream stream, string container, string identifier)
        {
            ContainerExistenceAssurance(container);
            var buffer = _containers[container][identifier];
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0;
        }

        public void Delete(string container, string identifier)
        {
            ContainerExistenceAssurance(container);
            _containers[container].Remove(identifier);
        }

        public bool Exists(string container, string identifier)
        {
            ContainerExistenceAssurance(container);
            return _containers[container].ContainsKey(identifier);
        }
    }
}