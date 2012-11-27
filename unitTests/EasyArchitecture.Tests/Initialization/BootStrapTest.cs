using System;
using EasyArchitecture.Initialization;
using Application4Test.Application.Contracts;
using EasyArchitecture.Tests.Stuff;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Initialization
{
    [TestFixture]
    public class BootstrapTest
    {

        [Test]
        public void GetInstance()
        {
            Bootstrap.GetInstance();
        }

        [Test]
        public void RegisterTest()
        {
            var bootstrap = Bootstrap.GetInstance();
            bootstrap.Register<IDogFacade, DummyDogFacade>();

            var facade = ServiceLocator.Current.GetInstance<IDogFacade>();

            Assert.That(facade, Is.InstanceOf<IDogFacade>());

            //T outside appfacade
            Assert.Throws<Exception>(bootstrap.Register<ICatFacade, DummyCatFacade>);

        }

    }
}
