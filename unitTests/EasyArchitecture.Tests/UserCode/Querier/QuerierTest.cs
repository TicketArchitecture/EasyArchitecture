using Application4Test.Application;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Infrastructure.Queriers;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using EasyArchitecture.Plugins.Automapper;
using EasyArchitecture.Plugins.Log4net;
using EasyArchitecture.Plugins.NHibernate;
using NHibernate;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode.Querier
{
    [TestFixture]
    public class QuerierTest
    {
        [Test]
        public void CanExecuteQuery()
        {

            //init
            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin());
            Bootstrap.Configure<IObjectMapperPlugin>(new AutoMapperPlugin());
            Bootstrap.Configure<IPersistencePlugin>(new NHibernatePlugin());

            Bootstrap.GetInstance();
            Bootstrap.GetInstance().Register<IDogFacade, DogFacade>();

            Bootstrap.GetInstance().OutterRegister<QuerierBase<DogDto>, DogQuerier>();//TODO: auto register needed

            var facade = Bootstrap.GetInstance().GetInstance<IDogFacade>();

            Assert.That(() => facade.GetAllDogs(), Throws.TypeOf<HibernateException>());

            Assert.That(() => facade.GetAllOldDogs(10), Throws.TypeOf<HibernateException>());


        }
    }
}
