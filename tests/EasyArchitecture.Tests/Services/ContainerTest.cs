using Application4Test.Application.Contracts;
using EasyArchitecture.Configuration;
using EasyArchitecture.IoC;
using EasyArchitecture.Runtime;
using EasyArchitecture.Tests.Stuff;
using NUnit.Framework;
using System.Collections.Generic;
using Application4Test.Application.Contracts.DTOs;


namespace EasyArchitecture.Tests.Services
{
    [TestFixture]
    public class ContainerTest
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
        public void Can_get_a_facade()
        {
            var facade = Container.Resolve<IDogFacade>();
            Assert.That(facade, Is.InstanceOf<IDogFacade>());
        }


        [Test]
        public void Can_get_a_overrided_facade()
        {
            Container.Register<IDogFacade, DummyDogFacade>();

            var facade = Container.Resolve<IDogFacade>();

            Assert.That(facade, Is.InstanceOf<IDogFacade>());

            var dtos = facade.GetDogs(new DogDto());
            List<DogDto> l = dtos as List<DogDto>;
            var actualDog = l.Find(
                delegate(DogDto dog)
                {

                    return dog.Name.Equals("DummyDog");
                });
            Assert.That(actualDog !=null);
        }

        //TODO: this test
        //T outside appfacade
        //Assert.Throws<Exception>(bootstrap.Register<ICatFacade, DummyCatFacade>);


    }
}
