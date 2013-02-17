using System;
using EasyArchitecture.Runtime;
using EasyArchitecture.Storage;
using EasyArchitecture.Storage.Plugin.Contracts;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Storage
{
    [TestFixture]
    public class StorageTest
    {
        private byte[] _buffer;
        private MockRepository _mockery;
        private IStorage _instancePlugin;

        [SetUp]
        public void SetUp()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<IStorage>();

            LocalThreadStorage.SetInstance(new EasyArchitecture.Storage.Instance.Storer(_instancePlugin));
            _buffer = new byte[10];
        }

        [Test]
        public void Should_store_file()
        {
            var id = Guid.NewGuid();

            Expect.Call(_instancePlugin.Save(_buffer)).Return(id);
            _mockery.ReplayAll();

            var ret = Storer.Save(_buffer);

            _mockery.VerifyAll();

            Assert.That(ret, Is.EqualTo(id));
        }

        [Test]
        public void Should_recover_file()
        {
            var id = Guid.NewGuid();

            Expect.Call( _instancePlugin.Get(id)).Return(_buffer);
            _mockery.ReplayAll();

            var ret = Storer.Get(id);

            _mockery.VerifyAll();

            Assert.That(ret, Is.EqualTo(_buffer));
        }

        [Test]
        public void Should_confirm_file_existence()
        {
            var id = Guid.NewGuid();

            Expect.Call(_instancePlugin.Exists(id)).Return(true);
            _mockery.ReplayAll();

            var actual = Storer.Exists(id);

            _mockery.VerifyAll();
            Assert.That(actual, Is.True);
        }
    }
}