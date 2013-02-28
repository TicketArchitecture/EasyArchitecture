using EasyArchitecture.Core;
using EasyArchitecture.Instances.Translation;
using EasyArchitecture.Plugin.Contracts.Translation;
using EasyArchitecture.Tests.Translation.Stuff;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Translation
{
    [TestFixture]
    public class TranslatorTest
    {
        private MockRepository _mockery;
        private ITranslator _instancePlugin;

        [SetUp]
        public void Setup()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<ITranslator>();

            LocalThreadStorage.GetCurrentContext().SetInstance(new Translator(_instancePlugin));
        }


        [Test]
        public void Can_get_a_dto_from_an_entity()
        {
            var entity = new Dog() { Id = 1, Age = 10, Name = "New Dog" };

            var expected = new DogDto() { Id = 1, Age = 10, Name = "New Dog" };

            Expect.Call(_instancePlugin.Translate<Dog,DogDto>(entity)).Return(expected);
            _mockery.ReplayAll();

            var actual = Mechanisms.Translation.Translator.This(entity).To<DogDto>();

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_get_an_entity_from_a_dto()
        {
            var dto = new DogDto() { Id = 1, Age = 10, Name = "New Dog" };
            var expected = new Dog() { Id = 1, Age = 10, Name = "New Dog" };

            Expect.Call(_instancePlugin.Translate<DogDto,Dog>(dto)).Return(expected);
            _mockery.ReplayAll();

            var actual = Mechanisms.Translation.Translator.This(dto).To<Dog>();

            _mockery.VerifyAll();
        }
    }
}
