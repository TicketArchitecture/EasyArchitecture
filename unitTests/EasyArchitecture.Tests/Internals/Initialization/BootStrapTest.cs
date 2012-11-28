using System;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using Application4Test.Application.Contracts;
using EasyArchitecture.Plugins.Log4net;
using EasyArchitecture.Tests.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Internals.Initialization
{
    [TestFixture]
    public class BootstrapTest
    {

        [Test]
        public void GetInstance()
        {
            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin()); 
            Bootstrap.GetInstance();
            
        }

        [Test]
        public void RegisterTest()
        {
            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin()); 
            var bootstrap = Bootstrap.GetInstance();
            bootstrap.Register<IDogFacade, DummyDogFacade>();

            var facade = Bootstrap.GetInstance().GetInstance<IDogFacade>();

            Assert.That(facade, Is.InstanceOf<IDogFacade>());

            //T outside appfacade
            Assert.Throws<Exception>(bootstrap.Register<ICatFacade, DummyCatFacade>);

        }

    }
}
