using System.Reflection;
using EasyArchitecture.Plugins.NHibernate.Persistence;
using EasyArchitecture.Plugins.NHibernate.Tests.Stuff;
using EasyArchitecture.Plugins.NHibernate.Tests.Stuff.Fluently;
using EasyArchitecture.Plugins.Tests.Persistence;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.NHibernate.Tests
{
    [TestFixture]
    public class FluentPersistenceTest:MinimalPersistenceTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new NHibernatePlugin();
            plugin.SetConfigurationInstance(new FluentlyNHibernateConfig());

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            PluginInstance = plugin.GetInstance();
        }
    }
}
