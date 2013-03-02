using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Tests.Translation;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.AutoMapper.Tests
{
    [TestFixture]
    public class TranslatorTest : MinimalTranslatorTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new AutoMapperPlugin();

            PluginInspector pluginInspector;
            plugin.Configure(new ModuleAssemblies(null, null, null, Assembly.GetExecutingAssembly()),
                             out pluginInspector);

            Translator = plugin.GetInstance();
        }
    }
}
