using System;

namespace EasyArchitecture.Log.Plugin.Contracts
{
    public interface ILoggerPlugin
    {
        void Log(LogLevel logLevel, object message, Exception exception);
        void Configure(string moduleName);
    }
}