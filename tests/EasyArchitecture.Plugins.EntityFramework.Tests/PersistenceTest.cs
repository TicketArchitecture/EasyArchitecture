using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugins.Validation.Persistence;
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
            plugin.Configure(new ModuleAssemblies(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
