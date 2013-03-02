using System;
using EasyArchitecture.Core.Log;
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

        internal Guid Save(byte[] buffer)
        {
            var ret =_plugin.Save(buffer);
            
            InstanceLogger.Log(this, "Save",buffer,ret);
            
            return ret;
        }

        internal byte[] Get(Guid id)
        {
            var ret=_plugin.Get(id);

            InstanceLogger.Log(this, "Get", id, ret);

            return ret;
        }

        internal bool Exists(Guid id)
        {
            var ret = _plugin.Exists(id);

            InstanceLogger.Log(this, "Exists", id, ret);

            return ret;
        }
    }
}

   
