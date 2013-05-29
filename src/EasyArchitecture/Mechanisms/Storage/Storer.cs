using System;
using System.IO;
using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Storage
{
    public static class Storer
    {
        public static void Save(Stream stream,string identifier)
        {
            InstanceProvider.GetInstance<Instances.Storage.Storer>().Save(stream,identifier);
        }

        public static void Retrieve(Stream stream, string identifier)
        {
            InstanceProvider.GetInstance<Instances.Storage.Storer>().Retrieve(stream,identifier);
        }

        public static bool Exists(string identifier)
        {
            return InstanceProvider.GetInstance<Instances.Storage.Storer>().Exists(identifier);
        }
    }
}
