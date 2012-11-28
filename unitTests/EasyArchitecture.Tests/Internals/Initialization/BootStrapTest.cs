using System;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using Application4Test.Application.Contracts;
using EasyArchitecture.Plugins.Automapper;
using EasyArchitecture.Plugins.Log4net;
using EasyArchitecture.Plugins.NHibernate;
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
            //init
            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin());
            Bootstrap.Configure<IObjectMapperPlugin>(new AutoMapperPlugin());
            Bootstrap.Configure<IPersistencePlugin>(new NHibernatePlugin());

            Bootstrap.GetInstance();
            
        }

        [Test]
        public void RegisterTest()
        {
            //init
            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin());
            Bootstrap.Configure<IObjectMapperPlugin>(new AutoMapperPlugin());
            Bootstrap.Configure<IPersistencePlugin>(new NHibernatePlugin());

            var bootstrap = Bootstrap.GetInstance();
            bootstrap.Register<IDogFacade, DummyDogFacade>();

            var facade = Bootstrap.GetInstance().GetInstance<IDogFacade>();

            Assert.That(facade, Is.InstanceOf<IDogFacade>());

            //T outside appfacade
            Assert.Throws<Exception>(bootstrap.Register<ICatFacade, DummyCatFacade>);

        }

    }
}
