using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Tests.IoC;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Unity.Tests
{
    [TestFixture]
    public class ContainerTest:MinimalContainerTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new UnityPlugin();

            var assembly = Assembly.GetExecutingAssembly();

            PluginInspector pluginInspector;
            plugin.Configure(new PluginConfiguration(string.Empty, assembly, assembly, assembly),
                             out pluginInspector);

            base.Container = plugin.GetInstance();
        }
    }
}
