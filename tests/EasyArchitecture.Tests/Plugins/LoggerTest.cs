using System;
using System.IO;
using EasyArchitecture.Common.Diagnostic;
using EasyArchitecture.Plugins.Default.Log;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class LoggerTest
    {
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        //deve criar arquivo, se nao existir
        [Test]
        public void Should_create_log_file_if_not_exists()
        {
            var moduleName = Guid.NewGuid().ToString();

            var logger = LoggerPlugin(moduleName,LogLevel.Debug);

            logger.Log(LogLevel.Debug, "message", null);

            var file = FileInfo(moduleName);
            //clean?
            //file.Delete();
            Assert.That(file,Is.Not.Null);
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


        [Test]
        public void Should_log_message()
        {
            var moduleName = Guid.NewGuid().ToString();
            var message = Guid.NewGuid().ToString();

            var logger = LoggerPlugin(moduleName,LogLevel.Fatal);

            logger.Log(LogLevel.Debug, message, null);

            var file = FileInfo(moduleName);
            var content = file.OpenText().ReadToEnd();

            Assert.That(content, Is.StringContaining(message));
        }
    }
}
