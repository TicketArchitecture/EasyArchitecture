namespace EasyArchitecture.Plugins
{
    public interface IConfigurablePlugin
    {
        void Configure(PluginConfiguration pluginConfiguration,out PluginInspector pluginInspector);
    }
}