using System;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Tests.Core.Stuff
{
    public class BuggedPlugin : AbstractPlugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            throw new Exception("Something wrong happen");
        }
    }
}