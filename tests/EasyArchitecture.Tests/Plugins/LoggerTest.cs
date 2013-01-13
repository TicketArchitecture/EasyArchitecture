using System;
using System.IO;
using EasyArchitecture.Log.Plugin.BultIn;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;
using NUnit.Framework;
using System.Threading;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class LoggerTest
    {
        private string _moduleName;
        private ILogger _logger;
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        [SetUp]
        public void SetUp()
        {
            _moduleName = Guid.NewGuid().ToString();
            
            var loggerPlugin = new LoggerPlugin();
            PluginInspector pluginInspector;
            loggerPlugin.Configure(new ModuleAssemblies(_moduleName, null, null, null), out pluginInspector);
            _logger = loggerPlugin.GetInstance();

        }


        [Test]
        public void Should_create_log_file_if_not_exists()
        {
            
            _logger.Log(LogLevel.Debug, "message", null);

            var file = FileInfo(_moduleName);

            Assert.That(file, Is.Not.Null);

            file.Delete();
        }


        [Test]
        public void Should_log_message()
        {
            var message = Guid.NewGuid().ToString();

            _logger.Log(LogLevel.Debug, message, null);

            var file = FileInfo(_moduleName);
            
            var reader = file.OpenText();

            var content = reader.ReadToEnd();
            reader.Close();

            Assert.That(content, Is.StringContaining(message));

            file.Delete();

        }

        [Test]
        public void Should_log_message_with_format()
        {
            var message = Guid.NewGuid().ToString();

            //2012-12-10 11:46:03,911 [CurrentAppDomainHost.ExecuteNodes] Debug e5ea10da-6545-400a-a130-f036648b3293

			var msgToLocate = string.Format("[{0}] DEBUG {1}", Thread.CurrentThread.Name, message);
            var dateOfMessage = DateTime.Now.ToString("yyyy-MM-dd");

            _logger.Log(LogLevel.Debug, message, null);

            var file = FileInfo(_moduleName);

            var reader = file.OpenText();

            var content = reader.ReadToEnd();
            reader.Close();

            Assert.That(content.Substring(0, 10), Is.StringContaining(dateOfMessage));
            Assert.That(content, Is.StringContaining(msgToLocate));

            file.Delete();

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
