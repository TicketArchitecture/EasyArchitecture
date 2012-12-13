using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public static class Storage
    {
        public static Guid Save(byte[] buffer)
        {
            return EasyConfigurations.SelectorByThread().Storage.Save(buffer);
        }
    }
}
