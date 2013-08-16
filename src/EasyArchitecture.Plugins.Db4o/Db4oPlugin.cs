using System;
using Db4objects.Db4o;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Persistence;

namespace EasyArchitecture.Plugins.Db4o
{
    public class Db4oPlugin: Plugin, IPersistencePlugin
    {

        private IObjectContainer db ;

        public IPersistence GetInstance()
        {
            return new Db4oPersistence(db);
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var assembly = pluginConfiguration.InfrastructureAssembly;
            var file = string.Format("\\db{0}.db", pluginConfiguration.ModuleName);

            db = Db4oFactory.OpenFile(AppDomain.CurrentDomain.BaseDirectory + file);
        }
    }
}
