using System;
using System.Threading;
using EasyArchitecture.Plugin.Contracts.Caching;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Validation.Caching
{
    [TestFixture]
    public abstract class MinimalCacheTest
    {
        protected ICache Cache;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Can_add_new_item()
        {
            var key = Guid.NewGuid().ToString();
            Assert.That(() => Cache.Add(key, 1), Throws.Nothing);

            var found = Cache.Contains(key);
            Assert.That(found, Is.True);

            var actual = Cache.GetData(key);
            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void Can_add_item_that_already_exists()
        {
            var key = Guid.NewGuid().ToString();
            Cache.Add(key, 1);

            Assert.That(() => Cache.Add(key, 2), Throws.Nothing);

            var found = Cache.Contains(key);
            Assert.That(found, Is.True);

            var actual = Cache.GetData(key);
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void Can_remove_existent_item()
        {
            var key = Guid.NewGuid().ToString();
            Cache.Add(key, 1);
            Cache.Remove(key);

            var found = Cache.Contains(key);
            Assert.That(found, Is.False);
        }

        [Test]
        public void Can_remove_inexistent_item()
        {
            var key = Guid.NewGuid().ToString();
            Assert.That(() => Cache.Remove(key), Throws.Nothing);
        }

        [Test]
        public void Can_clear_cache()
        {
            var key = Guid.NewGuid().ToString();
            Cache.Add(key, 1);

            Assert.That(() => Cache.Flush(), Throws.Nothing);

            var found = Cache.Contains(key);
            Assert.That(found, Is.False);
        }

        [Test]
        public void Can_verify_item_existence()
        {
            var key = Guid.NewGuid().ToString();
            Cache.Add(key, 1);

            var found = Cache.Contains(key);
            Assert.That(found, Is.True);
        }

        [Test]
        public void Can_verify_non_existence_of_item()
        {
            var key = Guid.NewGuid().ToString();
            var found = Cache.Contains(key);
            Assert.That(found, Is.False);
        }

        [Test]
        public void Should_not_item_stills_on_cache_after_expiration()
        {
            var key = Guid.NewGuid().ToString();
            Cache.Add(key, 1, new TimeSpan(0, 0, 1));

            var found = Cache.Contains(key);
            Assert.That(found, Is.True);

            //sleep
            Thread.Sleep(2000);

            found = Cache.Contains(key);
            Assert.That(found, Is.False);
        }
    }
}