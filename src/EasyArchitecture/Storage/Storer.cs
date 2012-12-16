using System;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Storage
{
    public static class Storer
    {
        public static Guid Save(byte[] buffer)
        {
            return InstanceProvider.GetInstance<Instance.Storer>().Save(buffer);
        }

        public static byte[] Get(Guid id)
        {
            return InstanceProvider.GetInstance<Instance.Storer>().Get(id);
        }

        public static bool Exists(Guid id)
        {
            return InstanceProvider.GetInstance<Instance.Storer>().Exists(id);
        }
    }
}
