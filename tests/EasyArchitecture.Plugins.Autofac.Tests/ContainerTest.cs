using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Mechanisms.IoC;
using EasyArchitecture.Plugins.Tests.IoC;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Autofac.Tests
{
    [TestFixture]
    public class ContainerTest:MinimalContainerTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new AutofacPlugin();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            Container = plugin.GetInstance();
        }
    }
}
