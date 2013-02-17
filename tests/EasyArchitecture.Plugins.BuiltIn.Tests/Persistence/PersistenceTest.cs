using System;
using EasyArchitecture.Persistence.Plugin.BultIn;
using EasyArchitecture.Plugins.Validation.Persistence;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Persistence
{
    [TestFixture]
    public class PersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var moduleName = Guid.NewGuid().ToString();

            var plugin = new PersistencePlugin();
            PluginInspector pluginInspector;
            plugin.Configure(new ModuleAssemblies(moduleName, null, null, null), out pluginInspector);
            PluginInstance = plugin.GetInstance();
        }
    }
}
