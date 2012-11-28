using EasyArchitecture.Initialization;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Diagnostic
{
    public class LogAction
    {
        private readonly LogMessage _message;
        private readonly string _moduleName;
        private LogLevel _logLevel;

        internal LogAction(LogMessage message)
        {
            _message = message;
            _moduleName = LocalThreadStorage.GetCurrentBusinessModuleName();
        }

        public void Debug()
        {
            //if (!_message.Logger.IsDebugEnabled)
            //    return;

            _logLevel=LogLevel.Debug;

            
        }

        public void Info()
        {
            //if (!_message.Logger.IsInfoEnabled)
            //    return;
            _logLevel = LogLevel.Info;

        }

        public void Warn()
        {
            //if (!_message.Logger.IsWarnEnabled)
            //    return;

            _logLevel = LogLevel.Warn;

        }

        public void Error()
        {
            //if (!_message.Logger.IsErrorEnabled)
            //    return;

            _logLevel = LogLevel.Error;
        }

        public void Fatal()
        {
            //if (!_message.Logger.IsFatalEnabled)
            //    return;

            _logLevel = LogLevel.Fatal;
        }

        private void Log()
        {
            Bootstrap.LogPlugin.Log(_logLevel, _moduleName, _message._message, _message._exception);
        }
    }
}