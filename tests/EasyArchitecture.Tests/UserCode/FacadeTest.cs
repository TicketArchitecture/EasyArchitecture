using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Configuration;
using EasyArchitecture.IoC;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode
{
    [TestFixture]
    public class FacadeTest
    {
        [SetUp]
        public void SetUp()
        {
            Configure
                .For<IDogFacade>()
                .Done();

        }

        [Test]
        public void Can_create_entity()
        {
            var facade = Container.Resolve<IDogFacade>();

            var expected = new DogDto() { Age = 10, Name = "Rex" };

            var actual = facade.CreateDog(new DogDto() {Age = 10, Name = "Rex"});

            Assert.That(actual,Is.EqualTo(expected));
        }

        [Test]
        public void Can_get_entity()
        {
            var facade = Container.Resolve<IDogFacade>();

            var expected = new DogDto() { Age = 10, Name = "Rex" };

            facade.CreateDog(new DogDto() { Age = 10, Name = "Rex" });
            var actual = facade.GetDog(new DogDto(){Age=10});

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_update_entity()
        {
            var facade = Container.Resolve<IDogFacade>();

            var expected = new DogDto() { Age = 200, Name = "Rex" };

            var actual = facade.CreateDog(new DogDto() { Age = 10, Name = "Rex" });
            actual.Age = 200;

            facade.UpdateDog(actual);
            
            actual = facade.GetDog(new DogDto() { Name="Rex" });

            Assert.That(actual, Is.EqualTo(expected));
        }

   }
}