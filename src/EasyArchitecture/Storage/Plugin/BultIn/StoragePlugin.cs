using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;
using EasyArchitecture.Storage.Plugin.Contracts;

namespace EasyArchitecture.Storage.Plugin.BultIn
{
    internal class StoragePlugin : AbstractPlugin,IStoragePlugin
    {
        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
        }

        public IStorage GetInstance()
        {
            return new Storage();
        }
    }
}