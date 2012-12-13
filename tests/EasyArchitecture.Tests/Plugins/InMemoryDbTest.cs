using Application4Test.Domain.Repositories;
using Application4Test.Infrastructure.Persistence.Repositories;
using EasyArchitecture.Configuration;
using EasyArchitecture.IoC.Mechanism;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class InMemoryDbTest
    {

        [SetUp]
        public void Setup()
        {
            Configure
                .For("Application4Test")
                .Done();


            //Garantir que sera usado a implementacao de persistencia local
            ServiceLocator.Register<IDogRepository, DogMemoryRepository>();

        }

        [Test]
        public void Can_call_facade()
        {
            //var facade = DependencyInjection.Resolve<IDogFacade>();

            //facade.CreateDog(new DogDto() {Name = "Teste", Age = 10});

            Assert.Inconclusive("Unfinished");
        }

        [Test]
        public void Can_call_query_method_in_facade()
        {
            //var facade = DependencyInjection.Resolve<IDogFacade>();

            //var dogs = facade.GetAllDogs();

            Assert.Inconclusive("Unfinished");
        }
    }
}
