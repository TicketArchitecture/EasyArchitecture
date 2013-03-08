using System.Reflection;
using EasyArchitecture.Plugins.NHibernate.Persistence;
using EasyArchitecture.Plugins.NHibernate.Tests.Stuff;
using EasyArchitecture.Plugins.NHibernate.Tests.Stuff.Code;
using EasyArchitecture.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.NHibernate.Tests
{
    [TestFixture]
    public class CodePersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new NHibernatePlugin();
            plugin.SetConfigurationInstance(new CodeNHibernateConfig());

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
