using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace EasyArchitecture.Diagnostic
{
    internal static class LogManager
    {
        private const string LogPattern = "%d [%t] %-5p %c - %m%n";

        private static Level GetLogLevel(string logLevel)
        {
            var _logLevel = Level.Error;

            if (!string.IsNullOrEmpty(logLevel))
            {

                if (string.Compare(logLevel, "Fatal", true) == 0)
                {
                    _logLevel = Level.Fatal;
                }
                else if (string.Compare(logLevel, "Warn", true) == 0)
                {
                    _logLevel = Level.Warn;
                }
                else if (string.Compare(logLevel, "Info", true) == 0)
                {
                    _logLevel = Level.Info;
                }
                else if (string.Compare(logLevel, "Debug", true) == 0)
                {
                    _logLevel = Level.Debug;
                }
            }

            return _logLevel;
        }

        public static void InitializeFrameworkLogger(string logLevel)
        {
            BasicConfigurator.Configure();

            var configLogLevel = GetLogLevel(logLevel);

            var defaultPattern = new PatternLayout { ConversionPattern = LogPattern };
            defaultPattern.ActivateOptions();

            var rollingFileAppender = new RollingFileAppender
            {
                Name = "RollingFileAppender",
                File = "Logs/EasyArchitecture.log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaxSizeRollBackups = 15,
                MaximumFileSize = "100MB",
                StaticLogFileName = true,
                Layout = defaultPattern
            };
            rollingFileAppender.ActivateOptions();

            var root = ((Hierarchy)log4net.LogManager.GetRepository()).Root;
            root.AddAppender(rollingFileAppender);
            root.Level = configLogLevel;
            root.Repository.Configured = true;

        }

        public static void Configure(string businessModuleName, string logLevel)
        {
            Log.To(typeof(LogManager)).Message("Configure log to [{0}] at [{1}] level",businessModuleName,logLevel).Debug();

            BasicConfigurator.Configure();

            var configLogLevel = GetLogLevel(logLevel);

            var defaultPattern = new PatternLayout { ConversionPattern = LogPattern };
            defaultPattern.ActivateOptions();


            var rollingFileAppender = new RollingFileAppender
            {
                Name = "RollingFileAppender",
                File = "Logs/" + businessModuleName + ".log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaxSizeRollBackups = 15,
                MaximumFileSize = "100MB",
                StaticLogFileName = true,
                Layout = defaultPattern
            };
            rollingFileAppender.ActivateOptions();

            var logger = (Logger)log4net.LogManager.GetLogger(businessModuleName).Logger;
            logger.AddAppender(rollingFileAppender);
            logger.Level = configLogLevel;
            logger.Repository.Configured = true;
        }

        public static void FinalizeFrameworkLogger()
        {
            var root = ((Hierarchy)log4net.LogManager.GetRepository()).Root;
            //root.CloseNestedAppenders();
            root.RemoveAllAppenders();
        }
    }
}
