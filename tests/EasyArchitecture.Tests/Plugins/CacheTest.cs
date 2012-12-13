using System;
using System.Threading;
using EasyArchitecture.Plugins.BuiltIn.Cache;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class CacheTest
    {
        private CachePlugin _cachePlugin;
        private string _key;

        [SetUp]
        public void SetUp()
        {
            _cachePlugin = new CachePlugin();
            _key = Guid.NewGuid().ToString();
        }

        [Test]
        public void Can_add_new_item()
        {
            Assert.That(() => _cachePlugin.Add(_key, 1), Throws.Nothing);

            var found = _cachePlugin.Contains(_key);
            Assert.That(found, Is.True);

            var actual = _cachePlugin.GetData(_key);
            Assert.That(actual, Is.EqualTo(1));

        }

        [Test]
        public void Can_add_item_that_already_exists()
        {
            _cachePlugin.Add(_key, 1);

            Assert.That(() => _cachePlugin.Add(_key, 2), Throws.Nothing);

            var found = _cachePlugin.Contains(_key);
            Assert.That(found, Is.True);

            var actual = _cachePlugin.GetData(_key);
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void Can_remove_existent_item()
        {
            _cachePlugin.Add(_key, 1);
            _cachePlugin.Remove(_key);

            var found = _cachePlugin.Contains(_key);
            Assert.That(found, Is.False);
        }

        [Test]
        public void Can_remove_inexistent_item()
        {
            Assert.That(() => _cachePlugin.Remove(_key), Throws.Nothing);
        }

        [Test]
        public void Can_clear_cache()
        {
            _cachePlugin.Add(_key, 1);

            Assert.That(()=>_cachePlugin.Flush(),Throws.Nothing);

            var found = _cachePlugin.Contains(_key);
            Assert.That(found, Is.False);
        }

        

        [Test]
        public void Can_verify_item_existence()
        {
            _cachePlugin.Add(_key, 1);
            
            var found = _cachePlugin.Contains(_key);
            Assert.That(found, Is.True);
        }

        [Test]
        public void Can_verify_non_existence_of_item()
        {
            var found = _cachePlugin.Contains(_key);
            Assert.That(found, Is.False);
        }


        [Test]
        public void Should_not_item_stills_on_cache_after_expiration()
        {
            _cachePlugin.Add(_key, 1,new TimeSpan(0,0,1));

            var found = _cachePlugin.Contains(_key);
            Assert.That(found,Is.True);
            
            //sleep
            Thread.Sleep(2000);

            found =_cachePlugin.Contains(_key);
            Assert.That(found, Is.False);
        }
    }
}