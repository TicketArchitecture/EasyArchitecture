using EasyArchitecture.Core;

namespace EasyArchitecture.Plugins
{
    public interface IConfigurablePlugin
    {
        void Configure(ModuleAssemblies moduleAssemblies,out PluginInspector pluginInspector);
    }
}