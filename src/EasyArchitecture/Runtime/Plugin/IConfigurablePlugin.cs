namespace EasyArchitecture.Runtime.Plugin
{
    public interface IConfigurablePlugin
    {
        void Configure(ModuleAssemblies moduleAssemblies,out PluginInspector pluginInspector);
    }
}