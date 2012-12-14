using System;
using System.Threading;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Caching.Plugin.BultIn;
using EasyArchitecture.Configuration;
using EasyArchitecture.IoC.Mechanism;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode
{
    [TestFixture]
    public class FacadeTest
    {
        [SetUp]
        public void SetUp()
        {
            Configure
                .For<Application4Test.Application.Contracts.IDogFacade>()
                .Done();

        }

        [Test]
        public void Can_call_facade()
        {

            var facade = ServiceLocator.Resolve<IDogFacade>();
            var dog = facade.CreateDog(new DogDto() {Age = 10, Name = "Rex"});
        }

   }
}