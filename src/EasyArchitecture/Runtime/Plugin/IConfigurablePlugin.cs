using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Runtime.Plugin
{
    public interface IConfigurablePlugin
    {
        void Configure(ModuleAssemblies moduleAssemblies);
    }
}