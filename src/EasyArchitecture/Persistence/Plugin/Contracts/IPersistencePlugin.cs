using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Persistence.Plugin.Contracts
{
    public interface IPersistencePlugin:IConfigurablePlugin,IInstanceProvider<IPersistence>
    {
    }
}