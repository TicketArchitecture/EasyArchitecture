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
            _moduleName = LocalThreadStorage.GetCurrentBusinessModuleName()??"EasyArchitecture";
        }

        public void Debug()
        {
            //if (!_message.Logger.IsDebugEnabled)
            //    return;

            _logLevel=LogLevel.Debug;
            Log();

            
        }

        public void Info()
        {
            //if (!_message.Logger.IsInfoEnabled)
            //    return;
            _logLevel = LogLevel.Info;
            Log();

        }

        public void Warn()
        {
            //if (!_message.Logger.IsWarnEnabled)
            //    return;

            _logLevel = LogLevel.Warn;
            Log();

        }

        public void Error()
        {
            //if (!_message.Logger.IsErrorEnabled)
            //    return;

            _logLevel = LogLevel.Error;
            Log();
        }

        public void Fatal()
        {
            //if (!_message.Logger.IsFatalEnabled)
            //    return;

            _logLevel = LogLevel.Fatal;
            Log();
        }

        private void Log()
        {
            if (Bootstrap.LogPlugin!=null)

            Bootstrap.LogPlugin.Log(_logLevel, _moduleName, _message._message, _message._exception);
        }
    }
}