using System;
using System.IO;
using EasyArchitecture.Plugins.Contracts.Storage;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Tests.Storage
{
    [TestFixture]
    public abstract class MinimalStorageTest
    {
        protected IStorage Storage;
        private const string Container = "teste-container";

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_store_file()
        {
            var buffer = new byte[] { 1, 2, 3, 4 };
            var id = Guid.NewGuid().ToString();
            
            using(var stream = new MemoryStream(buffer))
            {
                Assert.That(() => { Storage.Save(stream, Container,id); }, Throws.Nothing);
            }
            
        }

        [Test]
        public void Should_recover_file()
        {
            var buffer = new byte[] { 1, 2, 3, 4 };
            var id = Guid.NewGuid().ToString();

            var recoveredBuffer = new byte[4];

            using (var stream = new MemoryStream(buffer))
            {
                Storage.Save(stream, Container, id); 
            }

            using (var stream = new MemoryStream())
            {
                Storage.Retrieve(stream, Container, id);
                stream.Read(recoveredBuffer, 0, 4);
            }
            
            Assert.That(recoveredBuffer, Is.EqualTo(buffer));
        }

        [Test]
        public void Should_not_recover_an_inexistent_file()
        {
            var id = Guid.NewGuid().ToString();

            using (var stream = new MemoryStream())
            {
                Assert.That(() => { Storage.Retrieve(stream, Container,id); }, Throws.Exception);
            }
        }


        [Test]
        public void     Should_confirm_file_existence()
        {
            var buffer = new byte[] { 1, 2, 3, 4 };
            var id = Guid.NewGuid().ToString();

            using (var stream = new MemoryStream(buffer))
            {
                Storage.Save(stream, Container, id);
            }

            var actual = Storage.Exists(Container, id);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Should_confirm_file_inexistence()
        {
            var id = Guid.NewGuid().ToString();

            var actual = Storage.Exists(Container, id);

            Assert.That(actual, Is.False);
        }
    }
}
