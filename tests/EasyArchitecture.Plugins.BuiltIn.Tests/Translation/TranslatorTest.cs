using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.BultIn.Translation;
using EasyArchitecture.Plugins.Validation.Translation;
using EasyArchitecture.Plugins.Validation.Translation.Stuff;
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
