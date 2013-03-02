using System;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.BultIn.Log;
using EasyArchitecture.Plugins.Tests.Log;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Log
{
    [TestFixture]
    public class LoggerTest:MinimalLoggerTest
    {
        [SetUp]
        public override void SetUp()
        {
            ModuleName = Guid.NewGuid().ToString();

            var loggerPlugin = new LoggerPlugin();
            PluginInspector pluginInspector;
            loggerPlugin.Configure(new PluginConfiguration(ModuleName, null, null, null), out pluginInspector);
            Logger = loggerPlugin.GetInstance();
        }
    }
}
