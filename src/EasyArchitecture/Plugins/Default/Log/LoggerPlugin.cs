using System;
using System.IO;
using EasyArchitecture.Common.Diagnostic;

namespace EasyArchitecture.Plugins.Default.Log
{
    public class LoggerPlugin : ILoggerPlugin
    {
        private FileInfo _arquivo;
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        public void Configure(string moduleName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultPath);
            Directory.CreateDirectory(path);

            var logFile = Path.ChangeExtension(moduleName, DefaultExtension);
            logFile = Path.Combine(path, logFile);

            _arquivo = new FileInfo(logFile);
        }

        public void Log(LogLevel logLevel, object message, Exception exception)
        {
            using (var writer = _arquivo.AppendText()) 
            {
                writer.WriteLine(message);
            }
        }
    }
}