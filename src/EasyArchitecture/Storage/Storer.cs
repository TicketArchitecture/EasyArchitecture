using System;
using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Storage
{
    public static class Storer
    {
        public static Guid Save(byte[] buffer)
        {
            return EasyConfigurations.SelectorByThread().Storage.Save(buffer);
        }

        public static byte[] Get(Guid id)
        {
            return EasyConfigurations.SelectorByThread().Storage.Get(id);
        }

        public static bool Exists(Guid id)
        {
            return EasyConfigurations.SelectorByThread().Storage.Exists(id);
        }
    }
}
