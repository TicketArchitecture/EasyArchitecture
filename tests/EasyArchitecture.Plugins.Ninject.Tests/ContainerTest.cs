using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugins.Tests.IoC;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Ninject.Tests
{
    [TestFixture]
    [Ignore("POC")]
    public class ContainerTest : MinimalContainerTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new NinjectPlugin();

            PluginInspector pluginInspector;
            plugin.Configure(new ModuleAssemblies(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            Container = plugin.GetInstance();
        }
    }
}
