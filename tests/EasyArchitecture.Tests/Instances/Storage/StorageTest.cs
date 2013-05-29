using System;
using EasyArchitecture.Core;
using EasyArchitecture.Instances.Storage;
using EasyArchitecture.Plugins.Contracts.Log;
using EasyArchitecture.Plugins.Contracts.Storage;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Instances.Storage
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

            ThreadContext.Create("EasyArchitecture.Tests");
            ThreadContext.GetCurrent().SetInstance(new Storer(_instancePlugin));
            ThreadContext.GetCurrent().SetInstance(new EasyArchitecture.Instances.Log.Logger(MockRepository.GenerateStub<ILogger>()));

            _buffer = new byte[10];
        }

        //TODO: continuar
        //[Test]
        //public void Should_store_file()
        //{
        //    var id = Guid.NewGuid();

        //    Expect.Call(_instancePlugin.Save(_buffer)).Return(id);
        //    _mockery.ReplayAll();

        //    var ret = Mechanisms.Storage.Storer.Save(_buffer);

        //    _mockery.VerifyAll();

        //    Assert.That(ret, Is.EqualTo(id));
        //}

        //[Test]
        //public void Should_recover_file()
        //{
        //    var id = Guid.NewGuid();

        //    Expect.Call( _instancePlugin.Get(id)).Return(_buffer);
        //    _mockery.ReplayAll();

        //    var ret = Mechanisms.Storage.Storer.Get(id);

        //    _mockery.VerifyAll();

        //    Assert.That(ret, Is.EqualTo(_buffer));
        //}

        //[Test]
        //public void Should_confirm_file_existence()
        //{
        //    var id = Guid.NewGuid();

        //    Expect.Call(_instancePlugin.Exists(id)).Return(true);
        //    _mockery.ReplayAll();

        //    var actual = Mechanisms.Storage.Storer.Exists(id);

        //    _mockery.VerifyAll();
        //    Assert.That(actual, Is.True);
        //}
    }
}