using System;
using System.Collections;
using System.Collections.Generic;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    internal class PersistencePlugin : AbstractPlugin,IPersistencePlugin
    {
        private readonly Dictionary<Type, ArrayList> _dataBase = new Dictionary<Type, ArrayList>();

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
        }

        public IPersistence GetInstance()
        {
            return new Persistence(_dataBase);
        }
    }
}