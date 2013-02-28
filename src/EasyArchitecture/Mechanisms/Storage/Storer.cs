using System;
using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Storage
{
    public static class Storer
    {
        public static Guid Save(byte[] buffer)
        {
            return InstanceProvider.GetInstance<Instances.Storage.Storer>().Save(buffer);
        }

        public static byte[] Get(Guid id)
        {
            return InstanceProvider.GetInstance<Instances.Storage.Storer>().Get(id);
        }

        public static bool Exists(Guid id)
        {
            return InstanceProvider.GetInstance<Instances.Storage.Storer>().Exists(id);
        }
    }
}
