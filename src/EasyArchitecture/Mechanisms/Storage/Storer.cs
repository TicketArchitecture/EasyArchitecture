using System.Collections.Generic;
using System.IO;
using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Storage
{
    public static class Storer
    {
        public static void Save(Stream stream,string container, string identifier)
        {
            InstanceProvider.GetInstance<Instances.Storage.Storer>().Save(stream,container,identifier);
        }

        public static void Retrieve(Stream stream, string container, string identifier)
        {
            InstanceProvider.GetInstance<Instances.Storage.Storer>().Retrieve(stream,container,identifier);
        }

        public static bool Exists(string container, string identifier)
        {
            return InstanceProvider.GetInstance<Instances.Storage.Storer>().Exists(container,identifier);
        }

        public static void Delete(string container, string identifier)
        {
            InstanceProvider.GetInstance<Instances.Storage.Storer>().Delete(container, identifier);
        }

        public static IEnumerable<string> List(string container)
        {
            return InstanceProvider.GetInstance<Instances.Storage.Storer>().List(container);
        }

    }
}
