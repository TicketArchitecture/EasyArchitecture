using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Infrastructure.Queriers;
using EasyArchitecture.Initialization;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Use.Querier
{
    [TestFixture]
    public class QuerierTest
    {
        [Test]
        public void CanExecuteQuery()
        {
            Bootstrap.GetInstance();
            Bootstrap.GetInstance().OutterRegister<EasyArchitecture.Data.NHibernateQuerier<DogDto>, DogQuerier>();//TODO: auto register needed

            var facade = ServiceLocator.Current.GetInstance<IDogFacade>();

            Assert.That(() => facade.GetAllDogs(), Throws.TypeOf<NHibernate.HibernateException>());

            Assert.That(() => facade.GetAllOldDogs(10), Throws.TypeOf<NHibernate.HibernateException>());


        }
    }
}
