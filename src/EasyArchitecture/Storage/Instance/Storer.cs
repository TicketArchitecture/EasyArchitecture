using System;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Instance
{
    internal class Storer
    {
        private readonly IStorage _plugin;

        internal Storer(IStorage plugin)
        {
            _plugin = plugin;
        }

        internal Guid Save(byte[] buffer)
        {
            return _plugin.Save(buffer);
        }

        internal byte[] Get(Guid id)
        {
            return _plugin.Get(id);
        }

        internal bool Exists(Guid id)
        {
            return _plugin.Exists(id);
        }
    }
}

   
