using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Configuration;

namespace EasyArchitecture.Core.Contracts
{
    internal interface IConfigurableFactory
    {
        void Configure(PluginConfiguration pluginConfiguration, out PluginInspector pluginInspector);
    }
}