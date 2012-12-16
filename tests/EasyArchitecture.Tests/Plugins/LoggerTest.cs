using System;
using System.IO;
using EasyArchitecture.Log.Plugin.BultIn;
using EasyArchitecture.Log.Plugin.Contracts;
using NUnit.Framework;
using System.Threading;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class LoggerTest
    {
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        [Test]
        public void Should_create_log_file_if_not_exists()
        {
            var moduleName = Guid.NewGuid().ToString();

            var logger = LoggerPlugin(moduleName, LogLevel.Debug).GetInstance();

            logger.Log(LogLevel.Debug, "message", null);

            var file = FileInfo(moduleName);

            Assert.That(file, Is.Not.Null);

            file.Delete();
        }


        [Test]
        public void Should_log_message()
        {
            var moduleName = Guid.NewGuid().ToString();
            var message = Guid.NewGuid().ToString();

            var logger = LoggerPlugin(moduleName, LogLevel.Fatal).GetInstance();

            logger.Log(LogLevel.Debug, message, null);

            var file = FileInfo(moduleName);
            
            var reader = file.OpenText();

            var content = reader.ReadToEnd();
            reader.Close();

            Assert.That(content, Is.StringContaining(message));

            file.Delete();

        }

        [Test]
        public void Should_log_message_with_format()
        {
            var moduleName = Guid.NewGuid().ToString();
            var message = Guid.NewGuid().ToString();

            //2012-12-10 11:46:03,911 [CurrentAppDomainHost.ExecuteNodes] Debug e5ea10da-6545-400a-a130-f036648b3293

			var msgToLocate = string.Format("[{0}] DEBUG {1}", Thread.CurrentThread.Name, message);
            var dateOfMessage = DateTime.Now.ToString("yyyy-MM-dd");

            var logger = LoggerPlugin(moduleName, LogLevel.Fatal).GetInstance();

            logger.Log(LogLevel.Debug, message, null);

            var file = FileInfo(moduleName);

            var reader = file.OpenText();

            var content = reader.ReadToEnd();
            reader.Close();

            Assert.That(content.Substring(0, 10), Is.StringContaining(dateOfMessage));
            Assert.That(content, Is.StringContaining(msgToLocate));

            file.Delete();

        }

        private static LoggerPlugin LoggerPlugin(string moduleName, LogLevel logLevel)
        {
            var logger = new LoggerPlugin();
            logger.Configure(moduleName);
            return logger;
        }

        private static FileInfo FileInfo(string moduleName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultPath);
            var logFile = Path.ChangeExtension(moduleName, DefaultExtension);
            logFile = Path.Combine(path, logFile);

            var file = new FileInfo(logFile);
            return file;
        }
    }
}
