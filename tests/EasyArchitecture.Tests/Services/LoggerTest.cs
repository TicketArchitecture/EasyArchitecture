using EasyArchitecture.Configuration;
using EasyArchitecture.Log;
using EasyArchitecture.Runtime;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Services
{
    [TestFixture]
    public class LoggerTest
    {
        [SetUp]
        public void SetUp()
        {
            Configure
                .For("Application4Test")
                .Done();

            LocalThreadStorage.SetCurrentModuleName("Application4Test");
        }

        [Test]
        public void Should_create_log_file_if_not_exists()
        {
            //colocar um mock, e ver se chama o debug do plugin =)

            Logger.Message("abacate").Debug();

            //Guid? id = null;

            //Assert.That(() => { id = Storage.Save(_buffer); }, Throws.Nothing);
            //Assert.That(id, Is.Not.Null);
        }
    }
}