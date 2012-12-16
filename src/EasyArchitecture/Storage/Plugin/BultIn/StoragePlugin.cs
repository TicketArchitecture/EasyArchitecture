using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Runtime;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Plugin.BultIn
{
    internal class StoragePlugin : IStoragePlugin
    {
        public IStorage GetInstance()
        {
            return new Storage();
        }

        public void Configure(ModuleAssemblies moduleAssemblies)
        {
            throw new NotImplementedException();
        }
    }
}