using System;
using EasyArchitecture.Core.Serializer;
using EasyArchitecture.Mechanisms.Log.Expressions;

namespace EasyArchitecture.Mechanisms.Log
{
    public static class Logger
    {
        public static ActionExpression Message(string message, params object[] objs)
        {
            message = string.Format(message, objs);
            message = string.Format("   [Message]: {0}", message);

            return new ActionExpression(message);
        }

        public static ActionExpression Raw(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            message = string.Format("   [Raw]: {0}", message);

            return new ActionExpression(message);
        }

        public static ActionExpression Exception(Exception exception)
        {
            var message = string.Format("   [Exception]: ");

            return new ActionExpression(message, exception);
        }

        public static ActionExpression Exception(Exception exception, string message, params object[] objs)
        {
            message = string.Format(message, objs);
            message = string.Format("   [Exception]: {0} ", message);

            return new ActionExpression(message, exception);
        }
    }
}