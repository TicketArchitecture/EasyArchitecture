using System;
using EasyArchitecture.Plugins.Contracts.Persistence;

namespace EasyArchitecture.Plugins.Db4o
{
    public class Db4oPlugin : Plugin, IPersistencePlugin
    {

        private string _path;

        public IPersistence GetInstance()
        {
            return new Db4oPersistence(_path);
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var file = string.Format("db{0}.db", pluginConfiguration.ModuleName);
            _path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
        }
    }
}
