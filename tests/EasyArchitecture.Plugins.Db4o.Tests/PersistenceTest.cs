using System;
using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Db4o.Tests
{
    [TestFixture]
    public class PersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new Db4oPlugin();
            var moduleName = Guid.NewGuid().ToString();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(moduleName, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
