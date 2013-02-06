using System;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Log.Expressions
{
    public class ActionExpression
    {
        private readonly Exception _exception;
        private readonly object _message;
        private LogLevel _logLevel;

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
            _logLevel=LogLevel.Debug;
            Log();
        }

        public void Info()
        {
            _logLevel = LogLevel.Info;
            Log();
        }

        public void Warn()
        {
            _logLevel = LogLevel.Warn;
            Log();
        }

        public void Error()
        {
            _logLevel = LogLevel.Error;
            Log();
        }

        public void Fatal()
        {
            _logLevel = LogLevel.Fatal;
            Log();
        }

        private void Log()
        {
            InstanceProvider.GetInstance<Instance.Logger>().Log(_logLevel,  _message, _exception);
        }
    }
}