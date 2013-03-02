using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
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

            PluginInspector pluginInspector;
            plugin.Configure(new ModuleAssemblies(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            base.Container = plugin.GetInstance();
        }
    }
}
