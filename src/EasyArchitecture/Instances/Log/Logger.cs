using System;
using System.Collections.Generic;
using EasyArchitecture.Core;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Instances.Log
{
    internal class Logger
    {
        private readonly ILogger _plugin;
        internal readonly LogLevel _logLevel;
        private static readonly List<LogLevel> SequencialListOfLogLevel = new List<LogLevel> { LogLevel.Debug, LogLevel.Info, LogLevel.Warn, LogLevel.Error, LogLevel.Fatal };

        internal Logger(ILogger plugin)
        {
            _plugin = plugin;
            _logLevel = LoggerConfig.LoadRuntimeConfiguration(LocalThreadStorage.GetCurrentContext().Name);
        }

        internal void Log(LogLevel logLevel, object message, Exception exception)
        {
            if (ShouldSendToLog(logLevel, _logLevel))
                _plugin.Log(logLevel, message, exception);
        }

        private static bool ShouldSendToLog(LogLevel logLevel, LogLevel defaultLogLevel)
        {
            return SequencialListOfLogLevel.FindIndex(l => l == logLevel) >= SequencialListOfLogLevel.FindIndex(l => l == defaultLogLevel);
        }
    }
}