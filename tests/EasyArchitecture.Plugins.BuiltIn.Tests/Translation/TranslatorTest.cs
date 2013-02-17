using EasyArchitecture.Plugins.Validation.Translation;
using EasyArchitecture.Translation.Plugin.BultIn;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Translation
{
    [TestFixture]
    public class TranslatorTest:MinimalTranslatorTest
    {
        [SetUp]
        public override void SetUp()
        {
            Translator = new TranslatorPlugin().GetInstance();
        }
    }
}
