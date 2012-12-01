using System;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class LoggerActionExpression
    {
        private readonly Exception _exception;
        private readonly object _message;
        //private readonly string _moduleName;
        private LogLevel _logLevel;

        private LoggerActionExpression()
        {
            //_moduleName = LocalThreadStorage.GetCurrentBusinessModuleName()??"EasyArchitecture";
        }

        public LoggerActionExpression(object message):this()
        {
            _message = message;
        }

        public LoggerActionExpression(Exception exception): this()
        {
            _exception = exception;
        }

        public LoggerActionExpression(object message, Exception exception)
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
            //discovery instance
            var moduleName = LocalThreadStorage.GetCurrentBusinessModuleName();
            //execute
            EasyConfigurations.Configurations[moduleName].Logger.Log(_logLevel, moduleName, _message, _exception);
        }
    }
}