using System;
using EasyArchitecture.Plugin.Contracts.Storage;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Tests.Storage
{
    [TestFixture]
    public abstract class MinimalStorageTest
    {
        protected IStorage Storage;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_store_file()
        {
            var buffer = new byte[] { 1, 2, 3, 4 };
            Guid? id = null;

            Assert.That(() => { id = Storage.Save(buffer); }, Throws.Nothing);
            Assert.That(id, Is.Not.Null);
        }

        [Test]
        public void Should_recover_file()
        {
            var buffer = new byte[] { 1, 2, 3, 4 };
            var id = Storage.Save(buffer);

            var expected = buffer;
            var actual = Storage.Get(id);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_not_recover_an_inexistent_file()
        {
            var id = Guid.NewGuid();

            Assert.That(() => { Storage.Get(id); }, Throws.Exception);
        }


        [Test]
        public void Should_confirm_file_existence()
        {
            var buffer = new byte[] { 1, 2, 3, 4 };
            var id = Storage.Save(buffer);

            var actual = Storage.Exists(id);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Should_confirm_file_inexistence()
        {
            var id = Guid.NewGuid();

            var actual = Storage.Exists(id);

            Assert.That(actual, Is.False);
        }
    }
}
