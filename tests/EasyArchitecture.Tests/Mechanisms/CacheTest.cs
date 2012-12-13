using System;
using System.Threading;
using EasyArchitecture.Caching;
using EasyArchitecture.Configuration;
using EasyArchitecture.Runtime;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Mechanisms
{
    [TestFixture]
    public class CacheTest
    {
        private string _key;

        [SetUp]
        public void SetUp()
        {
            Configure
                .For("Application4Test")
                .Done();

            LocalThreadStorage.SetCurrentModuleName("Application4Test");

            _key = Guid.NewGuid().ToString();
        }

        [Test]
        public void Should_add()
        {
            Assert.That(() => Cache.This(1).With.NoExpiration.At(_key), Throws.Nothing);

            var found = Cache.Exists.At(_key);
            Assert.That(found, Is.True);

            var actual = Cache.Get.At(_key);
            Assert.That(actual, Is.EqualTo(1));

        }

        [Test]
        public void Should_remove()
        {
            Cache.This(1).With.NoExpiration.At(_key);
            Cache.Remove.At(_key);

            var found = Cache.Exists.At(_key);
            Assert.That(found, Is.False);
        }


        [Test]
        public void Should_clear()
        {
            Cache.This(1).With.NoExpiration.At(_key);

            Assert.That(() => Cache.Clear(), Throws.Nothing);

            var found = Cache.Exists.At(_key);
            Assert.That(found, Is.False);
        }


        [Test]
        public void Should_expiration()
        {
            Cache.This(1).With.ExpirationOf(1).Seconds.At(_key);

            var found = Cache.Exists.At(_key);
            Assert.That(found, Is.True);

            //sleep
            Thread.Sleep(2000);

            found = Cache.Exists.At(_key);
            Assert.That(found, Is.False);
        }
    }
}