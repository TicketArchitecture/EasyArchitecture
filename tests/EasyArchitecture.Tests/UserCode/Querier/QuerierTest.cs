//using Application4Test.Application;
//using Application4Test.Application.Contracts;
//using Application4Test.Application.Contracts.DTOs;
//using Application4Test.Infrastructure.Queriers;
////using EasyArchitecture.Data;
//using EasyArchitecture.Initialization;
//using NHibernate;
//using NUnit.Framework;

//namespace EasyArchitecture.Tests.UserCode.Querier
//{
//    [TestFixture]
//    public class QuerierTest
//    {
//        [Test]
//        public void CanExecuteQuery()
//        {

//            Bootstrap.GetInstance();
//            Bootstrap.GetInstance().Register<IDogFacade, DogFacade>();

//            Bootstrap.GetInstance().OutterRegister<QuerierBase<DogDto>, DogQuerier>();//TODO: auto register needed

//            var facade = Bootstrap.GetInstance().GetInstance<IDogFacade>();

//            Assert.That(() => facade.GetAllDogs(), Throws.TypeOf<HibernateException>());

//            Assert.That(() => facade.GetAllOldDogs(10), Throws.TypeOf<HibernateException>());


//        }
//    }
//}
