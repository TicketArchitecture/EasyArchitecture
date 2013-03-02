using System;
using System.Configuration;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Instances.Log
{
    internal static class LoggerConfig
    {
        internal static LogLevel LoadRuntimeConfiguration(string moduleName)
        {
            var key = String.Format("{0}.Logger.LogLevel", moduleName);
            var value = ConfigurationManager.AppSettings[key];
            return (GetLogLevel(value));
        }

        private static LogLevel GetLogLevel(string logLevel)
        {
            var level = LogLevel.Error;

            if (!String.IsNullOrEmpty(logLevel))
            {

                if (String.Compare(logLevel, "Fatal", true) == 0)
                {
                    level = LogLevel.Fatal;
                }
                else if (String.Compare(logLevel, "Warn", true) == 0)
                {
                    level = LogLevel.Warn;
                }
                else if (String.Compare(logLevel, "Info", true) == 0)
                {
                    level = LogLevel.Info;
                }
                else if (String.Compare(logLevel, "Debug", true) == 0)
                {
                    level = LogLevel.Debug;
                }
            }

            return level;
        }
    }
}