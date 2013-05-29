using System.Collections.Generic;
using System.IO;

namespace EasyArchitecture.Plugins.Contracts.Storage
{
    public interface IStorage
    {
        bool Exists (string identifier);
        void Save(Stream stream, string identifier);
        List<string> List();
        void Retrieve(Stream stream, string identifier);
        void Delete(string identifier);
    }
}
