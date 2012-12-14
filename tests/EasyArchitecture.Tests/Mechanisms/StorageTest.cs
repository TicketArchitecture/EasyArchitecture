using System;
using System.IO;
using EasyArchitecture.Configuration;
using EasyArchitecture.Runtime;
using EasyArchitecture.Storage;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Mechanisms
{
    [TestFixture]
    public class StorageTest
    {
        private byte[] _buffer;

        [SetUp]
        public void SetUp()
        {
            Configure
                .For("Application4Test")
                .Done();

            LocalThreadStorage.SetCurrentModuleName("Application4Test");

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Stuff/File", "Metallica-SadButTrue.txt");
            var file = new FileInfo(filePath);
            _buffer = new byte[file.Length];
            file.OpenRead().Read(_buffer, 0, (int)file.Length);
        }

        [Test]
        public void Should_store_file()
        {
            Guid? id = null;

            Assert.That(() => { id = Storer.Save(_buffer); },Throws.Nothing);
            Assert.That( id , Is.Not.Null);
        }

        [Test]
        public void Should_recover_file()
        {
            var id = Storer.Save(_buffer);
            
            var expected = _buffer;
            var actual = Storer.Get(id);

            Assert.That(actual,Is.EqualTo(expected));
        }

        [Test]
        public void Should_not_recover_an_inexistent_file()
        {
            var id = Guid.NewGuid();

            Assert.That(() => { Storer.Get(id); }, Throws.Exception); //TODO: create specific exception StorageFileNotFoundException
        }


        [Test]
        public void Should_confirm_file_existence()
        {
            var id = Storer.Save(_buffer);

            var actual = Storer.Exists(id);

            Assert.That(actual, Is.True);

        }

        [Test]
        public void Should_confirm_file_inexistence()
        {
            var id = Guid.NewGuid();

            var actual = Storer.Exists(id);

            Assert.That(actual, Is.False);

        }
    }
}