using System.Collections.Generic;
using System.IO;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class FileSystemStorage : IStorage
    {
        private readonly string _defaultPath;
        public FileSystemStorage(string defaultPath)
        {
            _defaultPath = defaultPath;
        }

        public void Save(Stream stream, string container, string identifier)
        {
            var buffer = new byte[stream.Length];

            stream.Read(buffer, 0, (int) stream.Length);

            var directory = ContainerExistenceAssurance(container);

            var fullpath = Path.Combine(directory.FullName, identifier);
            using (var fileStream = File.Create(fullpath, (int) stream.Length))
            {
                stream.CopyTo(fileStream);
                //var bytesInStream = new byte[stream.Length];
                //stream.Read(bytesInStream, 0, bytesInStream.Length);
                //fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
    

        private DirectoryInfo ContainerExistenceAssurance(string container)
        {
            var containerPath = Path.Combine(_defaultPath, container);
            return !Directory.Exists(containerPath) ? Directory.CreateDirectory(containerPath) : new DirectoryInfo(containerPath);
        }

        public IEnumerable<string> List(string container)
        {
            var directory = ContainerExistenceAssurance(container);
            return Directory.GetFiles(directory.FullName);
        }

        public void Retrieve(Stream stream, string container, string identifier)
        {
            var directory =  ContainerExistenceAssurance(container);
            var fullpath = Path.Combine(directory.FullName, identifier);
            using (var fileStream = File.OpenRead((fullpath)))
            {
                fileStream.CopyTo(stream);
            }
            stream.Position = 0;
        }

        public void Delete(string container, string identifier)
        {
            var directory = ContainerExistenceAssurance(container);
            var fullpath = Path.Combine(directory.FullName, identifier);
            File.Delete(fullpath);
        }

        public bool Exists(string container, string identifier)
        {
            var directory = ContainerExistenceAssurance(container);
            var fullpath = Path.Combine(directory.FullName, identifier);
            return File.Exists(fullpath);
        }
    }
}