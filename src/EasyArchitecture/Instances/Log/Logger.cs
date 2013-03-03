using System;
using System.Collections.Generic;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Log;

namespace EasyArchitecture.Instances.Log
{
    internal class Logger
    {
        private readonly ILogger _plugin;
        internal readonly LogLevel LogLevel;
        private static readonly List<LogLevel> SequencialListOfLogLevel = new List<LogLevel> { LogLevel.Debug, LogLevel.Info, LogLevel.Warn, LogLevel.Error, LogLevel.Fatal };

        internal Logger(ILogger plugin)
        {
            _plugin = plugin;
            LogLevel = LoggerConfig.LoadRuntimeConfiguration(ThreadContext.GetCurrent().ConfigurationName);
        }

        private void Log(LogLevel logLevel, object message, Exception exception)
        {
            if (ShouldSendToLog(logLevel, LogLevel))
                _plugin.Log(logLevel, ThreadContext.GetCurrent().Identifier, message, exception);
        }

        private static bool ShouldSendToLog(LogLevel logLevel, LogLevel defaultLogLevel)
        {
            return SequencialListOfLogLevel.FindIndex(l => l == logLevel) >= SequencialListOfLogLevel.FindIndex(l => l == defaultLogLevel);
        }

        internal void LogDebug(object message, Exception exception)
        {
            Log(LogLevel.Debug, message, exception);
        }

        internal void LogInfo(object message, Exception exception)
        {
            Log(LogLevel.Info, message, exception);
        }

        internal void LogWarn(object message, Exception exception)
        {
            Log(LogLevel.Warn, message, exception);
        }

        internal void LogError(object message, Exception exception)
        {
            Log(LogLevel.Error, message, exception);
        }

        internal void LogFatal(object message, Exception exception)
        {
            Log(LogLevel.Fatal, message, exception);
        }
    }
}