using System;
using EasyArchitecture.Storage.Plugin.BultIn;
using EasyArchitecture.Storage.Plugin.Contracts;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class StorageTest
    {
        private byte[] _buffer;
        private IStorage _plugin;


        [SetUp]
        public void SetUp()
        {
            _plugin = new StoragePlugin().GetInstance();
            _buffer = new byte[] { 1, 2, 3, 4 };
        }

        [Test]
        public void Should_store_file()
        {
            Guid? id = null;

            Assert.That(() => { id = _plugin.Save(_buffer); }, Throws.Nothing);
            Assert.That(id, Is.Not.Null);
        }

        [Test]
        public void Should_recover_file()
        {
            var id = _plugin.Save(_buffer);

            var expected = _buffer;
            var actual = _plugin.Get(id);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_not_recover_an_inexistent_file()
        {
            var id = Guid.NewGuid();

            Assert.That(() => { _plugin.Get(id); }, Throws.Exception);
        }


        [Test]
        public void Should_confirm_file_existence()
        {
            var id = _plugin.Save(_buffer);

            var actual = _plugin.Exists(id);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Should_confirm_file_inexistence()
        {
            var id = Guid.NewGuid();

            var actual = _plugin.Exists(id);

            Assert.That(actual, Is.False);
        }
    }
}
