using System;
using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Storage
{
    public static class Storer
    {
        public static Guid Save(byte[] buffer)
        {
            return ConfigurationSelector.SelectorByThread().Storage.Save(buffer);
        }

        public static byte[] Get(Guid id)
        {
            return ConfigurationSelector.SelectorByThread().Storage.Get(id);
        }

        public static bool Exists(Guid id)
        {
            return ConfigurationSelector.SelectorByThread().Storage.Exists(id);
        }
    }
}
