using EasyArchitecture.Plugins.Contracts.Log;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using ILogger = EasyArchitecture.Plugins.Contracts.Log.ILogger;

namespace EasyArchitecture.Plugins.log4net
{
    public class Log4NetPlugin :Plugin, ILoggerPlugin
    {
        private string _moduleName;
        private const string LogPattern = "%d [%t] %-5p %m%n";

        public ILogger GetInstance()
        {
            return new Log4NetLogger(_moduleName);
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            _moduleName = pluginConfiguration.ModuleName;
            BasicConfigurator.Configure();

            var defaultPattern = new PatternLayout { ConversionPattern = LogPattern };
            defaultPattern.ActivateOptions();

            var rollingFileAppender = new RollingFileAppender
            {
                Name = "RollingFileAppender",
                File = "Log/" + _moduleName + ".log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaxSizeRollBackups = 15,
                MaximumFileSize = "100MB",
                StaticLogFileName = true,
                Layout = defaultPattern
            };
            rollingFileAppender.ActivateOptions();
            rollingFileAppender.ImmediateFlush = true;
            rollingFileAppender.LockingModel= new FileAppender.InterProcessLock();

            var root = ((Hierarchy)global::log4net.LogManager.GetRepository()).Root;
            root.AddAppender(rollingFileAppender);
            root.Level = Level.Debug;
            root.Repository.Configured = true;
        }
    }
}
