using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using EasyArchitecture.Plugins.Automapper;
using EasyArchitecture.Plugins.Log4net;
using EasyArchitecture.Plugins.NHibernate;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode.Initialization
{
    [TestFixture]
    public class TranslationTest
    {
        [Test]
        public void CanTranslate()
        {
            //init
            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin());
            Bootstrap.Configure<IObjectMapperPlugin>(new AutoMapperPlugin());
            Bootstrap.Configure<IPersistencePlugin>(new NHibernatePlugin());

            Bootstrap.GetInstance();

            var expected = new Dog() {Age = 1,Id = 1,Name = "one"};

            var dto = new DogDto() {Age = 1,Id = 1,Name = "one"};

            var actual = Bootstrap.ObjectMapperPlugin.Map<DogDto, Dog>(dto);

            Assert.That(actual,Is.EqualTo(expected));

        }
    }
}
