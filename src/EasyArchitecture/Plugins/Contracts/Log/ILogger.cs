using System;

namespace EasyArchitecture.Plugins.Contracts.Log
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, Guid identifier, object message, Exception exception);
    }
}