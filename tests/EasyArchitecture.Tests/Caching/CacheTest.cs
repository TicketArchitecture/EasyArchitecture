using System;
using EasyArchitecture.Core;
using EasyArchitecture.Mechanisms.Caching;
using EasyArchitecture.Plugins.Contracts.Caching;
using EasyArchitecture.Plugins.Contracts.Log;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Caching
{
    [TestFixture]
    public class CacheTest
    {
        private MockRepository _mockery;
        private ICache _instancePlugin;

        [SetUp]
        public void SetUp()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<ICache>();

            ThreadContext.Create("EasyArchitecture.Tests");
            ThreadContext.GetCurrent().SetInstance(new Instances.Caching.Cache(_instancePlugin));
            ThreadContext.GetCurrent().SetInstance(new Instances.Log.Logger(MockRepository.GenerateStub<ILogger>()));
        }

        [Test]
        public void Should_add()
        {
            var key = Guid.NewGuid().ToString();

            Expect.Call(() => _instancePlugin.Add(key, 1));
            _mockery.ReplayAll();

            Cache.This(1).With.NoExpiration.At(key);

            _mockery.VerifyAll();
        }

        [Test]
        public void Should_remove()
        {
            var key = Guid.NewGuid().ToString();

            Expect.Call(() => _instancePlugin.Remove(key));
            _mockery.ReplayAll();

            Cache.Remove.At(key);

            _mockery.VerifyAll();
        }


        [Test]
        public void Should_clear()
        {
            Expect.Call(_instancePlugin.Flush);
            _mockery.ReplayAll();

            Cache.Clear();

            _mockery.VerifyAll();
        }


        [Test]
        public void Should_add_with_expiration()
        {
            var key = Guid.NewGuid().ToString();
            Expect.Call(() => _instancePlugin.Add(key, 1, new TimeSpan(0, 0, 1)));

            _mockery.ReplayAll();

            Cache.This(1).With.ExpirationOf(1).Seconds.At(key);

            _mockery.VerifyAll();
        }
    }
}