using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Mechanisms;
using EasyArchitecture.Plugins.Automapper;
using EasyArchitecture.Plugins.Default.DI;
using EasyArchitecture.Plugins.Log4net;
using EasyArchitecture.Plugins.NHibernate;
using EasyArchitecture.Plugins.Unity;
using EasyArchitecture.Tests.Internals.DependencyInjection.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode.Application
{
    [TestFixture]
    public class Class1
    {

        [SetUp]
        public void Setup()
        {
            Configuration
                .For("Application4Test")
                .Log<Log4NetPlugin>()
                .DependencyInjection<UnityDependencyInjectionPlugin>() //TODO: depends
                .Persistence<NHibernatePlugin>()
                .ObjectMapper<AutoMapperPlugin>()
                    .Done();
        }

        [Test]
        public void Can_call_facade()
        {
            //var facade = DependencyInjection.Resolve<IDogFacade>();

            //facade.UpdateDog(new DogDto());

            Assert.Inconclusive("Unfinished");
            
        }
    }
}
