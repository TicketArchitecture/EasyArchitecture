using System;
using EasyArchitecture.Mechanisms.Log.Expressions;

namespace EasyArchitecture.Mechanisms.Log
{
    public static class Logger
    {
        public static ActionExpression Message(string message, params object[] objs)
        {
            return new ActionExpression(string.Format(message, objs));
        }

        public static ActionExpression Raw(object obj)
        {
            return new ActionExpression(obj);
        }

        public static ActionExpression Exception(Exception exception)
        {
            return new ActionExpression(exception);
        }

        public static ActionExpression Exception(Exception exception, string message, params object[] objs)
        {
            return new ActionExpression(string.Format(message, objs), exception);
        }
    }
}