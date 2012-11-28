using EasyArchitecture.Initialization;

namespace EasyArchitecture.Diagnostic
{
    internal static class LogManager
    {
        private const string LogPath = @"\Log";

        public static void InitializeFrameworkLogger(string logLevel)
        {
            var logFile = "Logs/EasyArchitecture.log";
            Bootstrap.LogPlugin.Configure( logFile, GetLogLevel(logLevel));
        }

        public static void Configure(string businessModuleName, string logLevel)
        {
            Log.To(typeof (LogManager)).Message("Configure log to [{0}] at [{1}] level", businessModuleName, logLevel).Debug();
            var logFile = "Logs/" + businessModuleName + ".log";
            Bootstrap.LogPlugin.Configure(businessModuleName, logFile, GetLogLevel(logLevel) );
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
