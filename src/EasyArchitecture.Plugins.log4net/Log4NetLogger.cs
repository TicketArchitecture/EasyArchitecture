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

        public void Log(LogLevel logLevel, Guid identifier, object message, Exception exception)
        {
            var logger = GetLogger(_moduleName);
            var msg = string.Format("[{0}] {1}", identifier, message); 

            switch (logLevel)
            {
                case LogLevel.Fatal:
                    logger.Fatal(msg,exception);
                    break;
                case LogLevel.Error:
                    logger.Error(msg, exception);
                    break;
                case LogLevel.Warn:
                    logger.Warn(msg, exception);
                    break;
                case LogLevel.Info:
                    logger.Info(msg, exception);
                    break;
                case LogLevel.Debug:
                    logger.Debug(msg, exception);
                    break;
            }
        }
    }
}
