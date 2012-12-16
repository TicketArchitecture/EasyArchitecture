using System;
using System.IO;
using EasyArchitecture.Log.Plugin.Contracts;

namespace EasyArchitecture.Log.Plugin.BultIn
{
    internal class Logger : ILogger
    {
        private FileInfo _arquivo;
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        public void Log(LogLevel logLevel, object message, Exception exception)
        {
            using (var writer = _arquivo.AppendText())
            {
                writer.WriteLine(
                    string.Format("{0} [{1}] {2} {3}{4}",
                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss,fff"),
                        System.Threading.Thread.CurrentThread.Name,
                        logLevel.ToString().ToUpperInvariant(),
                        message,
                        exception)
                );
            }
        }
    }
}