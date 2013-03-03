using System;
using System.IO;
using EasyArchitecture.Plugins.Contracts.Log;
using NUnit.Framework;
using System.Threading;

namespace EasyArchitecture.Plugins.Tests.Log
{
    [TestFixture]
    public abstract class MinimalLoggerTest
    {
        protected ILogger Logger;
        protected string ModuleName;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_create_log_file_if_not_exists()
        {
            Logger.Log(LogLevel.Debug, Guid.NewGuid(), "message", null);

            var content = GetFileContent(ModuleName);

            Assert.That(content, Is.Not.Null);
        }

        [Test]
        public void Should_log_message()
        {
            var message = Guid.NewGuid().ToString();

            Logger.Log(LogLevel.Debug, Guid.NewGuid(), message, null);

            var content = GetFileContent(ModuleName);

            Assert.That(content, Is.StringContaining(message));
        }

        [Test]
        public void Should_log_message_data()
        {
            var message = Guid.NewGuid().ToString();
            var identifier = Guid.NewGuid();
            var dateOfMessage = DateTime.Now.ToString("yyyy-MM-dd");

            Logger.Log(LogLevel.Debug, identifier, message, null);

            var content = GetFileContent(ModuleName);

            Assert.That(content, Is.StringContaining(dateOfMessage));
            Assert.That(content, Is.StringContaining(Thread.CurrentThread.Name));
            Assert.That(content, Is.StringContaining(LogLevel.Debug.ToString().ToUpperInvariant()));
            Assert.That(content, Is.StringContaining(identifier.ToString()));
            Assert.That(content, Is.StringContaining(message));
        }

        private static string GetFileContent(string moduleName)
        {
            const string defaultPath = "Log";
            const string defaultExtension = ".log";

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, defaultPath);
            var logFile = Path.ChangeExtension(moduleName, defaultExtension);
            logFile = Path.Combine(path, logFile);

            string ret;
            using (var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sw = new StreamReader(fs))
            {
                ret = sw.ReadToEnd();
            }
            return ret;
        }
    }
}
