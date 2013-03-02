using System;
using System.IO;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Log;

namespace EasyArchitecture.Plugins.BultIn.Log
{
    internal class LoggerPlugin : AbstractPlugin, ILoggerPlugin
    {
        private FileInfo _arquivo;
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultPath);
            Directory.CreateDirectory(path);

            var logFile = Path.ChangeExtension(moduleAssemblies.ModuleName, DefaultExtension);
            logFile = Path.Combine(path, logFile);

            _arquivo = new FileInfo(logFile);

            pluginInspector.Log("Logging to {0}", _arquivo.FullName);
        }
    
        public ILogger GetInstance()
        {
            return new Logger(_arquivo);
        }
    }
}