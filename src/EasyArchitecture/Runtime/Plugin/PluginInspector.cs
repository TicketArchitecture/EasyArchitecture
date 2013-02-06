using System;
using System.Text;

namespace EasyArchitecture.Runtime.Plugin
{
    public class PluginInspector
    {
        private readonly StringBuilder _buffer = new StringBuilder();
        private readonly StringBuilder _typeInfo = new StringBuilder();
        private readonly StringBuilder _detailInfo= new StringBuilder();

        public PluginInspector(object plugin)
        {
            _typeInfo.AppendFormat("Assembly: {0}", plugin.GetType().Assembly.FullName);
            _typeInfo.AppendLine();
            _typeInfo.AppendFormat("Type: {0}", plugin.GetType().FullName);
            _typeInfo.AppendLine();
        }

        public string ExtractInfo()
        {
            _buffer.AppendLine("Plugin Info");
            _buffer.Append(_typeInfo);

            if (_detailInfo.Length>0)
            {
                _buffer.AppendLine("Configuration Details");
                _buffer.Append(_detailInfo);
            }
            _buffer.AppendLine("=============================================================================================");
            return _buffer.ToString();
        }

        public void Log(string message, params object[] args)
        {
            message = "-> " + message;
            _detailInfo.AppendFormat(message, args);
            _detailInfo.AppendLine();
        }

        public bool HasException { get; set; }

        public void LogException(Exception exception)
        {
            //TODO: format exception
            var message = "-> " + exception.Message;
            _detailInfo.AppendLine(message);
        }
    }
}