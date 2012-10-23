using System;
using System.Collections.Generic;
using log4net;

namespace EasyArchitecture.Diagnostic
{
    public static class Log
    {
        private static readonly Dictionary<Type, ILog> Loggers = new Dictionary<Type, ILog>();
        private static readonly object LogLock = new object();

        private static ILog GetLogger(Type source)
        {
            lock (LogLock)
            {
                if (Loggers.ContainsKey(source))
                {
                    return Loggers[source];
                }
                ILog logger = log4net.LogManager.GetLogger(source);
                Loggers.Add(source, logger);
                return logger;
            }
        }

        public static LogMessage To(object source)
        {
            return new LogMessage(GetLogger(source.GetType()));
        }

        public static LogMessage To<T>()
        {
            return new LogMessage(GetLogger(typeof(T)));
        }

        public static LogMessage To(Type type)
        {
            return new LogMessage(GetLogger(type));
        }
    }
}