using System;

//TODO: usar business module name, instead of type to track log

namespace EasyArchitecture.Diagnostic
{
    public static class Log
    {
        //private static readonly Dictionary<Type, ILog> Loggers = new Dictionary<Type, ILog>();
        //private static readonly object LogLock = new object();

        //private static ILog GetLogger(Type source)
        //{
        //    lock (LogLock)
        //    {
        //        if (Loggers.ContainsKey(source))
        //        {
        //            return Loggers[source];
        //        }
        //        ILog logger = log4net.LogManager.GetLogger(source);
        //        Loggers.Add(source, logger);
        //        return logger;
        //    }
        //}

        public static LogMessage To(object source)
        {
            return new LogMessage(source.GetType());
        }

        public static LogMessage To<T>()
        {
            return new LogMessage(typeof(T));
        }

        public static LogMessage To(Type type)
        {
            return new LogMessage(type);
        }
    }
}