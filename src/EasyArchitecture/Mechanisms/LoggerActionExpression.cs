using System;
using EasyArchitecture.Common.Diagnostic;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class LoggerActionExpression
    {
        private readonly Exception _exception;
        private readonly object _message;
        private LogLevel _logLevel;

        internal LoggerActionExpression(object message)
        {
            _message = message;
        }

        internal LoggerActionExpression(Exception exception)
        {
            _exception = exception;
        }

        internal LoggerActionExpression(object message, Exception exception)
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
            EasyConfigurations.SelectorByThread().Logger.Log(_logLevel,  _message, _exception);
        }
    }
}