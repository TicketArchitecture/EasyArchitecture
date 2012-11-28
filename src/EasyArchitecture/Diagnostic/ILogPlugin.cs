using System;

//TODO: give a better interface
namespace EasyArchitecture.Diagnostic
{
    public interface ILogPlugin
    {
        void Configure(string logFile, string businessModuleName, LogLevel logLevel);
        void Configure(string logFile, LogLevel logLevel);
        void Log(LogLevel logLevel, string moduleName, object message, Exception exception);
    }
}