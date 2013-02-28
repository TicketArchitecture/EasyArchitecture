using System;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.BultIn.Log;
using EasyArchitecture.Plugins.Validation.Log;
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
            loggerPlugin.Configure(new ModuleAssemblies(ModuleName, null, null, null), out pluginInspector);
            Logger = loggerPlugin.GetInstance();
        }
    }
}
