using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Configuration;
using EasyArchitecture.IoC;
using NUnit.Framework;
using Application4Test.Domain;

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
            var actual = facade.GetDogs(new DogDto(){Age=10});
            actual = facade.GetDogs(new DogDto() { Age = 10 });

            Assert.That(actual.Count, Is.GreaterThan(0));
        }


        [Test]
        [Ignore("Test ignored, wait for persistence infra service corrections")]
        public void Can_put_dog_to_sleep()
        {
            var facade = Container.Resolve<IDogFacade>();
            var dogDto = facade.CreateDog(new DogDto() { Age = 1, Id = 100, Name = "AwakenDog", IsSleeping = false });

            facade.PutDogToSleep(dogDto);

            var dog = facade.GetDog(100);

            Assert.IsTrue(dog.IsSleeping);
        }
           

   }
}