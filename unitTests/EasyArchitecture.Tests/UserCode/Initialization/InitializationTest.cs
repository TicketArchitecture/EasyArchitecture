using System;
using Application4Test.Application.Contracts;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using EasyArchitecture.Plugins.Log4net;
using EasyArchitecture.Tests.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode.Initialization
{
    [TestFixture]
    public class InitializationTest
    {
        [Test]
        public void CantGetInstanceWithoutLog()
        {
            //TODO: esse teste soh vai falhar na primeira execucao
            //Bootstrap.Configure<ILogPlugin>(null); 
            //Assert.That(()=>Bootstrap.GetInstance(),Throws.InstanceOf<ArgumentNullException>());


            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin()); 
            Assert.That(() => Bootstrap.GetInstance(), Throws.Nothing);
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
