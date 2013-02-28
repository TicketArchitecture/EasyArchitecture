using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Plugin.Contracts.Persistence
{
    public interface IPersistencePlugin:IConfigurablePlugin,IInstanceProvider<IPersistence>
    {
    }
}