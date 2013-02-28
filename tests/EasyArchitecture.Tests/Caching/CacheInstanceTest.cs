using System;
using EasyArchitecture.Instances.Caching;
using EasyArchitecture.Plugin.Contracts.Caching;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Caching
{
    [TestFixture]
    public class CacheInstanceTest
    {
        private string _key;
        private MockRepository _mockery = new MockRepository();
        private ICache _cachePlugin;
        private Cache _cacheInstance;


        [SetUp]
        public void SetUp()
        {
            _mockery = new MockRepository();
            _cachePlugin = _mockery.DynamicMock<ICache>();

            _key = Guid.NewGuid().ToString();
        }

        [Test]
        public void Can_call_add_item()
        {
            Expect.Call(()=> _cachePlugin.Add(_key,1));

            _mockery.ReplayAll();

            _cacheInstance = new Cache(_cachePlugin);
            _cacheInstance.Add(_key, 1);

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_call_add_item_passing_timespan()
        {
            Expect.Call(() => _cachePlugin.Add(_key, 1,new TimeSpan(0,0,1)));

            _mockery.ReplayAll();

            _cacheInstance = new Cache(_cachePlugin);
            _cacheInstance.Add(_key, 1, new TimeSpan(0, 0, 1));

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_call_remove_item()
        {
            Expect.Call(() => _cachePlugin.Remove(_key));

            _mockery.ReplayAll();

            _cacheInstance = new Cache(_cachePlugin);
            _cacheInstance.Remove(_key);

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_call_clear_cache()
        {
            Expect.Call(_cachePlugin.Flush);

            _mockery.ReplayAll();

            _cacheInstance = new Cache(_cachePlugin);
            _cacheInstance.Flush();

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_call_verify_item_existence()
        {
            Expect.Call(_cachePlugin.Contains(_key)).Return(true);

            _mockery.ReplayAll();

            _cacheInstance = new Cache(_cachePlugin);
            var actual = _cacheInstance.Contains(_key);

            Assert.That(actual,Is.True);

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_call_get_item()
        {
            Expect.Call(_cachePlugin.GetData(_key)).Return(1);

            _mockery.ReplayAll();

            _cacheInstance = new Cache(_cachePlugin);
            var actual = _cacheInstance.GetData(_key);

            Assert.That(actual, Is.EqualTo(1));

            _mockery.VerifyAll();
        }

    }
}