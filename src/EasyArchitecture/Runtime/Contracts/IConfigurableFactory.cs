using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Runtime.Contracts
{
    internal interface IConfigurableFactory
    {
        void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector);
    }
}