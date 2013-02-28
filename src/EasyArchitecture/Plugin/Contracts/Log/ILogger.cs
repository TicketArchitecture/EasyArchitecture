using System;

namespace EasyArchitecture.Plugin.Contracts.Log
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, object message, Exception exception);
    }
}