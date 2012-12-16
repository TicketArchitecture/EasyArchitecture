using System;
using System.Collections.Generic;
using System.Configuration;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Log.Plugin.Contracts;

namespace EasyArchitecture.Log.Instance
{
    internal class Logger
    {
        private readonly ILogger _plugin;
        private readonly string _moduleName;
        private readonly LogLevel _logLevel;
        private static readonly List<LogLevel> SequencialListOfLogLevel= new List<LogLevel>{LogLevel.Debug,LogLevel.Info,LogLevel.Warn,LogLevel.Error,LogLevel.Fatal};

        //internal Logger(ModuleConfiguration easyConfig)
        //{
        //    _moduleName = easyConfig.ModuleName;
        //    _logLevel = LoadRuntimeConfiguration(_moduleName);
        //    _plugin = (ILoggerPlugin)easyConfig.Plugins[typeof(ILoggerPlugin)];
        //    _plugin.Configure(_moduleName);
        //}

        internal Logger(ILogger plugin)
        {
            _plugin = plugin;
            //_moduleName = easyConfig.ModuleName;
            //_logLevel = LoadRuntimeConfiguration(_moduleName);
            //_plugin = (ILoggerPlugin)easyConfig.Plugins[typeof(ILoggerPlugin)];
            //_plugin.Configure(_moduleName);
        }

        internal void Log(LogLevel logLevel, object message, Exception exception)
        {
            if (ShouldSendToLog(logLevel,_logLevel))
                _plugin.Log(logLevel, message, exception);
        }

        private static bool ShouldSendToLog(LogLevel logLevel,LogLevel defaultLogLevel)
        {
            return SequencialListOfLogLevel.FindIndex(l => l == logLevel) >= SequencialListOfLogLevel.FindIndex(l => l == defaultLogLevel);
        }

        private static LogLevel GetLogLevel(string logLevel)
        {
            var _logLevel = LogLevel.Error;

            if (!string.IsNullOrEmpty(logLevel))
            {

                if (string.Compare(logLevel, "Fatal", true) == 0)
                {
                    _logLevel = LogLevel.Fatal;
                }
                else if (string.Compare(logLevel, "Warn", true) == 0)
                {
                    _logLevel = LogLevel.Warn;
                }
                else if (string.Compare(logLevel, "Info", true) == 0)
                {
                    _logLevel = LogLevel.Info;
                }
                else if (string.Compare(logLevel, "Debug", true) == 0)
                {
                    _logLevel = LogLevel.Debug;
                }
            }

            return _logLevel;
        }

        private static LogLevel LoadRuntimeConfiguration(string moduleName)
        {
            var key = string.Format("Easy.Logger.Level.{0}", moduleName);
            var value = ConfigurationManager.AppSettings[key];
            return (GetLogLevel(value));
        }
    }
}
