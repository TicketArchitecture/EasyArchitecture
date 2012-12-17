using EasyArchitecture.Configuration;
using EasyArchitecture.Runtime;
using EasyArchitecture.Tests.Stuff.Translation;
using EasyArchitecture.Translation;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Services
{
    [TestFixture]
    public class TranslatorTest
    {
        [SetUp]
        public void Setup()
        {
            Configure
                .For("Application4Test")
                .Done();

            LocalThreadStorage.SetCurrentModuleName("Application4Test");

        }


        [Test]
//        [Ignore("Need to correct thread selector")]
        public void Can_get_a_dto_from_an_entity()
        {
            var entity = new Dog() { Id = 1, Age = 10, Name = "New Dog" };

            var expected = new DogDto() { Id = 1, Age = 10, Name = "New Dog" };

            var actual = Translator.This(entity).To<DogDto>();

            Assert.That(actual, Is.TypeOf<DogDto>());
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        [Test]
//        [Ignore("Need to correct thread selector")]
        public void Can_get_an_entity_from_a_dto()
        {
            var dto = new DogDto() { Id = 1, Age = 10, Name = "New Dog" };
            var expected = new Dog() { Id = 1, Age = 10, Name = "New Dog" };

            var actual = Translator.This(dto).To<Dog>();

            Assert.That(actual, Is.TypeOf<Dog>());
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

    }
}
