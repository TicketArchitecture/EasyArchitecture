using System;
using System.Text;

namespace EasyArchitecture.Runtime.Plugin
{
    public class PluginInspector
    {
        private StringBuilder buffer = new StringBuilder();
        private StringBuilder typeInfo = new StringBuilder();
        private StringBuilder detailInfo= new StringBuilder();

        public PluginInspector(object plugin)
        {
            typeInfo.AppendFormat("Assembly: {0}", plugin.GetType().Assembly.FullName);
            typeInfo.AppendLine();
            typeInfo.AppendFormat("Type: {0}", plugin.GetType().FullName);
            typeInfo.AppendLine();
        }


        public string ExtractInfo()
        {
            buffer.AppendLine("Plugin Info");
            buffer.Append(typeInfo);

            if (detailInfo.Length>0)
            {
                buffer.AppendLine("Configuration Details");
                buffer.Append(detailInfo);
            }
            buffer.AppendLine("=============================================================================================");
            return buffer.ToString();
        }

        public void Log(string message, params object[] args)
        {
            message = "-> " + message;
            detailInfo.AppendFormat(message, args);
            detailInfo.AppendLine();
        }

        public bool HasException { get; set; }

        public void LogException(Exception exception)
        {
            //TODO: format exception
            var message = "-> " + exception.Message;
            detailInfo.AppendLine(message);
        }
    }
}