using System;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Tests.Runtime.Stuff
{
    public class BuggedPlugin : AbstractPlugin
    {
        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            throw new Exception("Something wrong happen");
        }
    }
}