namespace EasyArchitecture.Core.Plugin
{
    public interface IConfigurablePlugin
    {
        void Configure(ModuleAssemblies moduleAssemblies,out PluginInspector pluginInspector);
    }
}