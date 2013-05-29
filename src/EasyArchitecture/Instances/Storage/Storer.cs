using System;
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

        internal void Save(Stream stream, string identifier)
        {
            _plugin.Save(stream, identifier);
            
            InstanceLogger.Log(this, "Save",stream.Length, identifier);
        }

        internal void Retrieve(Stream stream, string identifier)
        {
            _plugin.Retrieve(stream,identifier);

            InstanceLogger.Log(this, "Get", stream.Length, identifier);
        }

        internal bool Exists(string identifier)
        {
            var ret = _plugin.Exists(identifier);

            InstanceLogger.Log(this, "Exists", identifier, ret);

            return ret;
        }
    }
}

   
