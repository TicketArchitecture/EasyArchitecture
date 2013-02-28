using System.Collections.Generic;
using EasyArchitecture.Core;
using EasyArchitecture.Mechanisms.Persistence;
using EasyArchitecture.Plugin.Contracts.Persistence;
using EasyArchitecture.Tests.Persistence.Stuff;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Persistence
{
    [TestFixture]
    public class RepositoryTest
    {
        private Dog _dog;
        private MockRepository _mockery;
        private IPersistence _instancePlugin;

        [SetUp]
        public void SetUp()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<IPersistence>();

            LocalThreadStorage.CreateContext("EasyArchitecture.Tests");
            LocalThreadStorage.GetCurrentContext().SetInstance(new Instances.Persistence.Persistence(_instancePlugin));

            _dog = new Dog { Age = 15, Name = "Old Dog" };
        }

        [Test]
        public void Should_save_entity()
        {
            Expect.Call(() => _instancePlugin.Save(_dog));
            _mockery.ReplayAll();

            new Repository<Dog>().Save(_dog);

            _mockery.VerifyAll();
        }

        [Test]
        public void Should_get_entity()
        {
            Expect.Call(_instancePlugin.Get<Dog>(_dog)).Return(new List<Dog>());
            _mockery.ReplayAll();

            new Repository<Dog>().Get(_dog);

            _mockery.VerifyAll();
        }

        [Test]
        public void Should_update_entity()
        {
            Expect.Call(() => _instancePlugin.Update(_dog));
            _mockery.ReplayAll();

            new Repository<Dog>().Update(_dog);

            _mockery.VerifyAll();
        }

        [Test]
        public void Should_delete_entity()
        {
            Expect.Call(() => _instancePlugin.Delete(_dog));
            _mockery.ReplayAll();

            new Repository<Dog>().Delete(_dog);

            _mockery.VerifyAll();
        }
    }
}
