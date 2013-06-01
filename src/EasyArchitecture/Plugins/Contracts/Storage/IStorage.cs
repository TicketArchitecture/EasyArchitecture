using System.Collections.Generic;
using System.IO;

namespace EasyArchitecture.Plugins.Contracts.Storage
{
    public interface IStorage
    {
        bool Exists (string container, string identifier);
        void Save(Stream stream, string container, string identifier);
        IEnumerable<string> List(string container);
        void Retrieve(Stream stream, string container, string identifier);
        void Delete(string container, string identifier);
    }
}
