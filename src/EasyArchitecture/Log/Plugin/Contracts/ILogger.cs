using System;

namespace EasyArchitecture.Log.Plugin.Contracts
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, object message, Exception exception);
    }
}