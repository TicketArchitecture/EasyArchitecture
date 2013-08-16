using System;
using System.Configuration;
using System.IO;
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
            var key = String.Format("{0}.Db4oPlugin.DbFileLocation", pluginConfiguration.ModuleName);
            var value = ConfigurationManager.AppSettings[key];

            _path = value ??
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("db{0}.db", pluginConfiguration.ModuleName));
        }
    }
}
