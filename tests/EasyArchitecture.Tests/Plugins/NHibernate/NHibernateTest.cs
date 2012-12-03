using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain.Repositories;
using Application4Test.Infrastructure.Persistence.Repositories;
using EasyArchitecture.Mechanisms;
using EasyArchitecture.Plugins.Automapper;
using EasyArchitecture.Plugins.Log4net;
using EasyArchitecture.Plugins.NHibernate;
using EasyArchitecture.Plugins.Unity;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins.NHibernate
{
    [TestFixture]
    public class NHibernateTest
    {

        [SetUp]
        public void Setup()
        {
            Configuration
                .For("Application4Test")
                .Log<Log4NetPlugin>()                                   //Stable
                .DependencyInjection<UnityDependencyInjectionPlugin>()  //Stable
                .Persistence<NHibernatePlugin>()
                .ObjectMapper<AutoMapperPlugin>()                       //Stable
                .Done();


            //Garantir que sera usado a implementacao do nhibernate
            DependencyInjection.Register<IDogRepository,DogRepository>();

        }

        [Test]
        public void Can_call_facade()
        {
            var facade = DependencyInjection.Resolve<IDogFacade>();

            facade.CreateDog(new DogDto() {Name = "Teste", Age = 10});

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
