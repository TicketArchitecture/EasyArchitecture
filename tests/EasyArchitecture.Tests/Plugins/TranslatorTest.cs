using EasyArchitecture.Plugins.Default.DI;
using EasyArchitecture.Plugins.Default.Translation;
using EasyArchitecture.Tests.Stuff.DI;
using EasyArchitecture.Tests.Stuff.Translation;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class TranslatorTest
    {
        [Test]
        public void Should_match_same_name_properties()
        {
            var entity = new Dog() {Age = 15, Id = 8, Name = "Rex"};
            var expected= new DogDto() { Age = 15, Id = 8, Name = "Rex" };

            var actual= Translator.Translate<Dog, DogDto>(entity);

            Assert.That(actual, Is.EqualTo(expected));
        }


        //convention: same name

        //convert lists

        //use custom map


    }
}
