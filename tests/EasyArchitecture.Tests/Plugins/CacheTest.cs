using System;
using System.Threading;
using EasyArchitecture.Caching.Plugin.BultIn;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class CacheTest
    {
        private Cache _cache;
        private string _key;

        [SetUp]
        public void SetUp()
        {
            _cache = new Cache();
            _key = Guid.NewGuid().ToString();
        }

        [Test]
        public void Can_add_new_item()
        {
            Assert.That(() => _cache.Add(_key, 1), Throws.Nothing);

            var found = _cache.Contains(_key);
            Assert.That(found, Is.True);

            var actual = _cache.GetData(_key);
            Assert.That(actual, Is.EqualTo(1));

        }

        [Test]
        public void Can_add_item_that_already_exists()
        {
            _cache.Add(_key, 1);

            Assert.That(() => _cache.Add(_key, 2), Throws.Nothing);

            var found = _cache.Contains(_key);
            Assert.That(found, Is.True);

            var actual = _cache.GetData(_key);
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void Can_remove_existent_item()
        {
            _cache.Add(_key, 1);
            _cache.Remove(_key);

            var found = _cache.Contains(_key);
            Assert.That(found, Is.False);
        }

        [Test]
        public void Can_remove_inexistent_item()
        {
            Assert.That(() => _cache.Remove(_key), Throws.Nothing);
        }

        [Test]
        public void Can_clear_cache()
        {
            _cache.Add(_key, 1);

            Assert.That(()=>_cache.Flush(),Throws.Nothing);

            var found = _cache.Contains(_key);
            Assert.That(found, Is.False);
        }

        

        [Test]
        public void Can_verify_item_existence()
        {
            _cache.Add(_key, 1);
            
            var found = _cache.Contains(_key);
            Assert.That(found, Is.True);
        }

        [Test]
        public void Can_verify_non_existence_of_item()
        {
            var found = _cache.Contains(_key);
            Assert.That(found, Is.False);
        }


        [Test]
        public void Should_not_item_stills_on_cache_after_expiration()
        {
            _cache.Add(_key, 1,new TimeSpan(0,0,1));

            var found = _cache.Contains(_key);
            Assert.That(found,Is.True);
            
            //sleep
            Thread.Sleep(2000);

            found =_cache.Contains(_key);
            Assert.That(found, Is.False);
        }
    }
}