using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Mechanisms;
using EasyArchitecture.Plugins.Unity;
using EasyArchitecture.Tests.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode
{
    [TestFixture]
    public class DependencyInjectionTest
    {

        [SetUp]
        public void Setup()
        {
            Configuration
                .For("Application4Test")
                    .DependencyInjection<UnityDependencyInjectionPlugin>()
                    .Done();
        }

        [Test]
        public void Can_get_a_facade()
        {
            var facade = DependencyInjection.Resolve<IDogFacade>();

            Assert.That(facade, Is.InstanceOf<IDogFacade>());
        }


        [Test]
        public void Can_get_a_overrided_facade()
        {
            DependencyInjection.Register<IDogFacade, DummyDogFacade>();

            var facade = DependencyInjection.Resolve<IDogFacade>();

            Assert.That(facade, Is.InstanceOf<IDogFacade>());

            var dto = facade.GetDog(new DogDto());
            Assert.That(dto.Name, Is.EqualTo("DummyDog"));
        }

        //TODO: this test
                    //T outside appfacade
            //Assert.Throws<Exception>(bootstrap.Register<ICatFacade, DummyCatFacade>);


    }
}
