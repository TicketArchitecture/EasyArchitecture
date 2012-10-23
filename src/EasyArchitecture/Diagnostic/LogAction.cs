namespace EasyArchitecture.Diagnostic
{
    public class LogAction
    {
        private readonly LogMessage _message;

        internal LogAction(LogMessage message)
        {
            _message = message;
        }

        public void Debug()
        {
            if (!_message.Logger.IsDebugEnabled)
                return;

            if (_message._exception!=null)
            {
                _message.Logger.Debug(_message._message,_message._exception);
            }else
            {
                _message.Logger.Debug(_message._message);
            }
            
        }

        public void Info()
        {
            if (!_message.Logger.IsInfoEnabled)
                return;

            if (_message._exception != null)
            {
                _message.Logger.Info(_message._message, _message._exception);
            }
            else
            {
                _message.Logger.Info(_message._message);
            }
        }

        public void Warn()
        {
            if (!_message.Logger.IsWarnEnabled)
                return;
            
            if (_message._exception != null)
            {
                _message.Logger.Warn(_message._message, _message._exception);
            }
            else
            {
                _message.Logger.Warn(_message._message);
            }
        }

        public void Error()
        {
            if (!_message.Logger.IsErrorEnabled)
                return;
            
            if (_message._exception != null)
            {
                _message.Logger.Error(_message._message, _message._exception);
            }
            else
            {
                _message.Logger.Error(_message._message);
            }
        }

        public void Fatal()
        {
            if (!_message.Logger.IsFatalEnabled)
                return;
            
            if (_message._exception != null)
            {
                _message.Logger.Fatal(_message._message, _message._exception);
            }
            else
            {
                _message.Logger.Fatal(_message._message);
            }
        }
    }
}