using EasyArchitecture.Core;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Tests.Core.Stuff
{
    public class DummyPlugin : Plugin
    {
        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            pluginInspector.Log("Mensagem {0}","teste");
        }
    }
}
