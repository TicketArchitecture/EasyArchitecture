using System;
using System.IO;
using EasyArchitecture.Common.Diagnostic;

namespace EasyArchitecture.Plugins.Default.Log
{
    public class LogPlugin : ILogPlugin
    {
        private FileInfo _arquivo;
        private LogLevel _logLevel;
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        public void Configure(string moduleName, LogLevel logLevel)
        {
            _logLevel = logLevel;

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultPath);
            Directory.CreateDirectory(path);

            var logFile = Path.ChangeExtension(moduleName, DefaultExtension);
            logFile = Path.Combine(path, logFile);

            _arquivo = new FileInfo(logFile);
        }

        public void Log(LogLevel logLevel, string moduleName, object message, Exception exception)
        {
            //using (var reader = _arquivo.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            using (var reader = _arquivo.AppendText()) 
            //using (var fs = new StreamWriter(reader))
            {
                reader.WriteLine(message);
                //fs.WriteLine(message);
            }
        }
    }
}