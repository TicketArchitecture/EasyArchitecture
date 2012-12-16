using System;
using System.IO;
using System.Reflection;
using EasyArchitecture.Log.Plugin.Contracts;

namespace EasyArchitecture.Log.Plugin.BultIn
{
    internal class LoggerPlugin : ILoggerPlugin
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

        public void Configure(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public ILogger GetInstance()
        {
            return new Logger();
        }
    }
}