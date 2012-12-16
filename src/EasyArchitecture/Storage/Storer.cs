using System;
using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Storage
{
    public static class Storer
    {
        public static Guid Save(byte[] buffer)
        {
            return ConfigurationSelector.Selector().Storage.Save(buffer);
        }

        public static byte[] Get(Guid id)
        {
            return ConfigurationSelector.Selector().Storage.Get(id);
        }

        public static bool Exists(Guid id)
        {
            return ConfigurationSelector.Selector().Storage.Exists(id);
        }
    }
}
