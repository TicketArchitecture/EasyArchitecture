using System;
using System.Collections.Generic;
using EasyArchitecture.Core;
using EasyArchitecture.Plugin.Contracts.Log;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace EasyArchitecture.Instances.Log
{
    internal class Logger
    {
        private readonly ILogger _plugin;
        private readonly LogLevel _logLevel;
        private static readonly List<LogLevel> SequencialListOfLogLevel = new List<LogLevel> { LogLevel.Debug, LogLevel.Info, LogLevel.Warn, LogLevel.Error, LogLevel.Fatal };

        //TODO: must be internal but i did to activator use
        public Logger(ILogger plugin)
        {
            _plugin = plugin;
            _logLevel = LoadRuntimeConfiguration(LocalThreadStorage.GetCurrentContext().Name);
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

        private static LogLevel GetLogLevel(string logLevel)
        {
            var level = LogLevel.Error;

            if (!string.IsNullOrEmpty(logLevel))
            {

                if (string.Compare(logLevel, "Fatal", true) == 0)
                {
                    level = LogLevel.Fatal;
                }
                else if (string.Compare(logLevel, "Warn", true) == 0)
                {
                    level = LogLevel.Warn;
                }
                else if (string.Compare(logLevel, "Info", true) == 0)
                {
                    level = LogLevel.Info;
                }
                else if (string.Compare(logLevel, "Debug", true) == 0)
                {
                    level = LogLevel.Debug;
                }
            }

            return level;
        }

        private static LogLevel LoadRuntimeConfiguration(string moduleName)
        {
            var key = string.Format("{0}.Logger.LogLevel", moduleName);
            var value = ConfigurationManager.AppSettings[key];
            return (GetLogLevel(value));
        }
    }
}