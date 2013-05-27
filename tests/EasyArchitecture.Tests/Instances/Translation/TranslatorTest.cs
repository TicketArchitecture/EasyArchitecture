using EasyArchitecture.Core;
using EasyArchitecture.Instances.Translation;
using EasyArchitecture.Plugins.Contracts.Log;
using EasyArchitecture.Plugins.Contracts.Translation;
using EasyArchitecture.Tests.Instances.Translation.Stuff;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Instances.Translation
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

            ThreadContext.Create("EasyArchitecture.Tests");
            ThreadContext.GetCurrent().SetInstance(new Translator(_instancePlugin));
            ThreadContext.GetCurrent().SetInstance(new EasyArchitecture.Instances.Log.Logger(MockRepository.GenerateStub<ILogger>()));

        }


        [Test]
        public void Can_get_a_dto_from_an_entity()
        {
            var entity = new Dog() { Id = 1, Age = 10, Name = "New Dog" };

            var expected = new DogDto() { Id = 1, Age = 10, Name = "New Dog" };

            Expect.Call(_instancePlugin.Translate<Dog,DogDto>(entity)).Return(expected);
            _mockery.ReplayAll();

            var actual = Mechanisms.Translation.Translate.This(entity).Into<DogDto>();

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_get_an_entity_from_a_dto()
        {
            var dto = new DogDto() { Id = 1, Age = 10, Name = "New Dog" };
            var expected = new Dog() { Id = 1, Age = 10, Name = "New Dog" };

            Expect.Call(_instancePlugin.Translate<DogDto,Dog>(dto)).Return(expected);
            _mockery.ReplayAll();

            var actual = Mechanisms.Translation.Translate.This(dto).Into<Dog>();

            _mockery.VerifyAll();
        }
    }
}
