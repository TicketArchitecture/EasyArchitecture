using System;
using EasyArchitecture.Diagnostic;

namespace EasyArchitecture.Plugins.Default.Log
{
    public class LogPlugin : ILogPlugin
    {
        public void Configure(string logFile, string businessModuleName, LogLevel logLevel)
        {
            //throw new NotImplementedException();
        }

        public void Configure(string logFile, LogLevel logLevel)
        {
            //throw new NotImplementedException();
        }

        public void Log(LogLevel logLevel, string moduleName, object message, Exception exception)
        {
            //throw new NotImplementedException();
        }
    }
}