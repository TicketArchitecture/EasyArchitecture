using System;
using EasyArchitecture.Common.Diagnostic;

namespace EasyArchitecture.Plugins
{
    public interface ILoggerPlugin
    {
        void Log(LogLevel logLevel, object message, Exception exception);
        void Configure(string moduleName);
    }
}