using System.Collections.Generic;
using System.IO;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class MemoryStorage : IStorage
    {
        private static readonly Dictionary<string, Dictionary<string, byte[]>> Containers = new Dictionary<string, Dictionary<string, byte[]>>();

        public void Save(Stream stream, string container, string identifier)
        {
            var buffer = new byte[stream.Length];

            stream.Read(buffer, 0, (int)stream.Length);
  
            ContainerExistenceAssurance(container);
            Containers[container].Add(identifier, buffer);
        }

        private void ContainerExistenceAssurance(string container)
        {
            if (!Containers.ContainsKey(container))
                Containers.Add(container,new Dictionary<string, byte[]>());
        }

        public IEnumerable<string> List(string container)
        {
            ContainerExistenceAssurance(container);
            return new List<string>(Containers[container].Keys);
        }

        public void Retrieve(Stream stream, string container, string identifier)
        {
            ContainerExistenceAssurance(container);
            var buffer = Containers[container][identifier];
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0;
        }

        public void Delete(string container, string identifier)
        {
            ContainerExistenceAssurance(container);
            Containers[container].Remove(identifier);
        }

        public bool Exists(string container, string identifier)
        {
            ContainerExistenceAssurance(container);
            return Containers[container].ContainsKey(identifier);
        }
    }
}