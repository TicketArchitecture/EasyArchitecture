using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Plugin.BultIn
{
    internal class StoragePlugin : IStoragePlugin
    {
        public IStorage GetInstance()
        {
            return new Storage();
        }

        public void Configure(Assembly assembly)
        {
            throw new NotImplementedException();
        }
    }
}