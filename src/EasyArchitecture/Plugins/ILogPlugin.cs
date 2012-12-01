using System;
using EasyArchitecture.Diagnostic;

namespace EasyArchitecture.Plugins
{
    public interface ILogPlugin
    {
        void Configure(string logFile, string businessModuleName, LogLevel logLevel);
        void Log(LogLevel logLevel, string moduleName, object message, Exception exception);
    }
}