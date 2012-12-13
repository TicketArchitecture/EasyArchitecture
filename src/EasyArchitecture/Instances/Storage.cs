using System;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    public class Storage
    {
        private readonly EasyConfig _easyCofig;
        private readonly IStoragePlugin _plugin;

        internal Storage(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            _plugin = (IStoragePlugin)_easyCofig.Plugins[typeof(IStoragePlugin)];
        }

        public Guid Save(byte[] buffer)
        {
            return _plugin.Save(buffer);
        }
    }
}

   
