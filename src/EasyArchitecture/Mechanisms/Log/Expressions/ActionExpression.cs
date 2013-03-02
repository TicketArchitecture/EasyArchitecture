using System;
using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Log.Expressions
{
    public class ActionExpression
    {
        private readonly Exception _exception;
        private readonly object _message;

        internal ActionExpression(object message)
        {
            _message = message;
        }

        internal ActionExpression(Exception exception)
        {
            _exception = exception;
        }

        internal ActionExpression(object message, Exception exception)
        {
            _message = message;
            _exception = exception;
        }

        public void Debug()
        {
            InstanceProvider.GetInstance<Instances.Log.Logger>().LogDebug(_message, _exception);
        }

        public void Info()
        {
            InstanceProvider.GetInstance<Instances.Log.Logger>().LogInfo(_message, _exception);
        }

        public void Warn()
        {
            InstanceProvider.GetInstance<Instances.Log.Logger>().LogWarn(_message, _exception);
        }

        public void Error()
        {
            InstanceProvider.GetInstance<Instances.Log.Logger>().LogError(_message, _exception);
        }

        public void Fatal()
        {
            InstanceProvider.GetInstance<Instances.Log.Logger>().LogFatal(_message, _exception);
        }
    }
}