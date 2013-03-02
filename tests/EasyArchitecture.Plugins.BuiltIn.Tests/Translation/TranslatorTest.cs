using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.BultIn.Translation;
using EasyArchitecture.Plugins.Tests.Translation;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Translation
{
    [TestFixture]
    public class TranslatorTest:MinimalTranslatorTest
    {
        [SetUp]
        public override void SetUp()
        {
            var plugin = new TranslatorPlugin();

            PluginInspector pluginInspector;
            var infraAssembly = Assembly.GetExecutingAssembly();

            plugin.Configure(new ModuleAssemblies(null, null, null, infraAssembly), out pluginInspector);
            Translator = plugin.GetInstance();
        }
    }
}
