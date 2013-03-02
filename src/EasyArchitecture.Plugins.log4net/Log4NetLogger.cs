using System;
using System.Collections.Generic;
using EasyArchitecture.Plugins.Contracts.Log;
using log4net;

namespace EasyArchitecture.Plugins.log4net
{
    public class Log4NetLogger : ILogger
    {
        private static readonly Dictionary<string, ILog> Loggers = new Dictionary<string, ILog>();
        private static readonly object LogLock = new object();
        private readonly string _moduleName;

        public Log4NetLogger(string moduleName)
        {
            _moduleName = moduleName;
        }

        private static ILog GetLogger(string source)
        {
            lock (LogLock)
            {
                if (Loggers.ContainsKey(source))
                {
                    return Loggers[source];
                }
                ILog logger = LogManager.GetLogger(source);
                Loggers.Add(source, logger);
                return logger;
            }
        }

        public void Log(LogLevel logLevel,  object message, Exception exception)
        {
            var logger = GetLogger(_moduleName);

            switch (logLevel)
            {
                case LogLevel.Fatal:
                    logger.Fatal(message,exception);
                    break;
                case LogLevel.Error:
                    logger.Error(message, exception);
                    break;
                case LogLevel.Warn:
                    logger.Warn(message, exception);
                    break;
                case LogLevel.Info:
                    logger.Info(message, exception);
                    break;
                case LogLevel.Debug:
                    logger.Debug(message, exception);
                    break;
            }
        }
    }
}
