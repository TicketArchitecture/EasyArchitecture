using System.Collections.Generic;
using System.IO;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Instances.Storage
{
    internal class Storer
    {
        private readonly IStorage _plugin;

        internal Storer(IStorage plugin)
        {
            _plugin = plugin;
        }

        internal void Save(Stream stream, string container, string identifier)
        {
            _plugin.Save(stream, container,identifier);
            
            InstanceLogger.Log(this, "Save",stream.Length,container, identifier);
        }

        internal void Retrieve(Stream stream, string container, string identifier)
        {
            _plugin.Retrieve(stream,container,identifier);

            InstanceLogger.Log(this, "Retrieve", stream.Length, container, identifier);
        }

        internal bool Exists(string container, string identifier)
        {
            var ret = _plugin.Exists(container,identifier);

            InstanceLogger.Log(this, "Exists", container,identifier, ret);

            return ret;
        }

        internal IEnumerable<string> List(string container)
        {
            var ret = _plugin.List(container);

            InstanceLogger.Log(this, "List", container, ret);

            return ret;
        }

        internal void Delete(string container, string identifier)
        {
            _plugin.Delete(container, identifier);

            InstanceLogger.Log(this, "Delete", container,identifier);
        }
    }
}

   
