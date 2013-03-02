using System;

namespace EasyArchitecture.Plugins.Contracts.Log
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, object message, Exception exception);
    }
}