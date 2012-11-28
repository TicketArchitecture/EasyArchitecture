using System;

namespace EasyArchitecture.Diagnostic
{
    public static class Log
    {
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