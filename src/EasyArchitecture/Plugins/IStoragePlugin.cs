using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyArchitecture.Plugins
{
    public interface IStoragePlugin
    {
        Guid Save(byte[] buffer);
    }
}
