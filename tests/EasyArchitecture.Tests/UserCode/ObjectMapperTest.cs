using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain;
using EasyArchitecture.Mechanisms;
using EasyArchitecture.Plugins.Automapper;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode
{
    [TestFixture]
    public class ObjectMapperTest
    {
        [SetUp]
        public void Setup()
        {
            Configure
                .For("Application4Test")
                    .ObjectMapper<AutoMapperPlugin>()
                    .Done();
        }

        [Test]
        public void Can_get_a_dto_from_an_entity()
        {
            var entity = new Dog() { Id = 1, Age = 10, Name = "New Dog" };

            var expected = new DogDto() { Id = 1, Age = 10, Name = "New Dog" };
            
            var actual = Translator.This(entity).To<DogDto>();

            Assert.That(actual, Is.TypeOf<DogDto>());
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        [Test]
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
