using System;

namespace EasyArchitecture.Mechanisms
{
    public static class Logger
    {
        public static LoggerActionExpression Message(string message, params object[] objs)
        {
            return new LoggerActionExpression(string.Format(message, objs));
        }

        public static LoggerActionExpression Raw(object obj)
        {
            return new LoggerActionExpression(obj);
        }

        public static LoggerActionExpression Exception(Exception exception)
        {
            return new LoggerActionExpression(exception);
        }

        public static LoggerActionExpression Exception(Exception exception, string message, params object[] objs)
        {
            return new LoggerActionExpression(string.Format(message, objs), exception);
        }
    }
}