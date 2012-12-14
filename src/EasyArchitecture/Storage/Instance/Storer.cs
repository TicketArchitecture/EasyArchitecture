using System;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Instance
{
    internal class Storer
    {
        private readonly ModuleConfiguration _easyCofig;
        private readonly IStoragePlugin _plugin;

        internal Storer(ModuleConfiguration easyCofig)
        {
            _easyCofig = easyCofig;
            _plugin = (IStoragePlugin)_easyCofig.Plugins[typeof(IStoragePlugin)];
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

   
