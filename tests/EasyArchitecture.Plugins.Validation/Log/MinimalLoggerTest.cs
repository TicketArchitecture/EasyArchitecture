using System;
using System.IO;
using EasyArchitecture.Log.Plugin.Contracts;
using NUnit.Framework;
using System.Threading;

namespace EasyArchitecture.Plugins.Validation.Log
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
            Logger.Log(LogLevel.Debug, "message", null);

            var file = GetFileInfo(ModuleName);

            Assert.That(file, Is.Not.Null);
        }

        [Test]
        public void Should_log_message()
        {
            var message = Guid.NewGuid().ToString();

            Logger.Log(LogLevel.Debug, message, null);

            var file = GetFileInfo(ModuleName);

            var reader = file.OpenText();

            var content = reader.ReadToEnd();
            reader.Close();

            Assert.That(content, Is.StringContaining(message));
        }

        [Test]
        public void Should_log_message_with_format()
        {
            var message = Guid.NewGuid().ToString();

            //2012-12-10 11:46:03,911 [CurrentAppDomainHost.ExecuteNodes] Debug e5ea10da-6545-400a-a130-f036648b3293

            var msgToLocate = string.Format("[{0}] DEBUG {1}", Thread.CurrentThread.Name, message);
            var dateOfMessage = DateTime.Now.ToString("yyyy-MM-dd");

            Logger.Log(LogLevel.Debug, message, null);

            var file = GetFileInfo(ModuleName);

            var reader = file.OpenText();

            var content = reader.ReadToEnd();
            reader.Close();

            Assert.That(content.Substring(0, 10), Is.StringContaining(dateOfMessage));
            Assert.That(content, Is.StringContaining(msgToLocate));
        }

        private static FileInfo GetFileInfo(string moduleName)
        {
            const string defaultPath = "Log";
            const string defaultExtension = ".log";

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, defaultPath);
            var logFile = Path.ChangeExtension(moduleName, defaultExtension);
            logFile = Path.Combine(path, logFile);

            var file = new FileInfo(logFile);
            return file;
        }
    }
}
