using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.EntityFramework.Tests
{
    [TestFixture]
    [Ignore("POC")]
    public class PersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new EntityFrameworkPlugin();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
