using System;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class Logger
    {
        private readonly ILogPlugin _plugin;
        private readonly string _moduleName;

        internal Logger(EasyConfig easyConfig)
        {
            _moduleName = easyConfig.ModuleName;
            _plugin = (ILogPlugin)easyConfig.Plugins[typeof(ILogPlugin)];

            _plugin.Configure(_moduleName, GetLogLevel("debug"));
        }

        internal void Log(LogLevel logLevel, object message, Exception exception)
        {
            _plugin.Log(logLevel, _moduleName, message, exception);
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

    }
}
