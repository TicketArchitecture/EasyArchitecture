using System.Collections.Generic;
using EasyArchitecture.Plugins;
using EasyArchitecture.Tests.Core.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Core
{
    [TestFixture]
    public class PluginInspectorTest
    {
        [Test]
        public void Can_get_plugin_info()
        {
            var plugin = new DummyPlugin();
            PluginInspector pluginInspector;
            plugin.Configure(null,out pluginInspector);

            var info = new PluginInspectorExtrator(new List<PluginInspector> {pluginInspector}).ToString();

            Assert.That(info,Is.StringContaining("DummyPlugin"));
            Assert.That(info, Is.StringContaining("Mensagem teste"));
        }

        [Test]
        public void Should_capture_plugin_exception()
        {
            var plugin = new BuggedPlugin();
            PluginInspector pluginInspector;

            Assert.That(() => plugin.Configure(null, out pluginInspector),
                        Throws.InstanceOf<PluginConfigurationException>());

        }

    }
}