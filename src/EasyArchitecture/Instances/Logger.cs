using System;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class Logger
    {
        private readonly EasyConfig _easyConfig;

        internal Logger(EasyConfig easyConfig)
        {
            _easyConfig = easyConfig;

            //this.Configure(easyConfig.ModuleName, "debug");
            var logFile = "Logs/" + _easyConfig.ModuleName + ".log";

            //get plugin
            var plugin = (ILogPlugin)_easyConfig.Plugins[typeof(ILogPlugin)];

            //execute
            plugin.Configure(logFile, _easyConfig.ModuleName, GetLogLevel("debug"));

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

        //public static Logger GetCurrentLogger()
        //{
        //    var businessModuleName = LocalThreadStorage.GetCurrentBusinessModuleName();
        //    return EasyConfigurations.Loggers[businessModuleName];
        //}

        public void Log(LogLevel logLevel, string moduleName, object message, Exception exception)
        {
            //get plugin
            var plugin = (ILogPlugin)_easyConfig.Plugins[typeof(ILogPlugin)];

            //execute
            plugin.Log(logLevel, moduleName, message, exception);
        }

        //internal static void AddNew(EasyConfig easyConfig, ILogPlugin logPlugin)
        //{
        //    EasyConfigurations.Loggers[easyConfig.ModuleName] = new Logger(logPlugin, easyConfig.ModuleName);
        //}

        //public static Logger GetInstanceOf(string businessModule)
        //{
        //    return EasyConfigurations.Loggers[businessModule];
        //}

        //public ILogPlugin GetPlugin()
        //{
        //    return _logPlugin;
        //}
    }
}
