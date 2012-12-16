using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Storage.Plugin.Contracts
{
    public interface IStoragePlugin : IInstanceProvider<IStorage>, IConfigurablePlugin
    {
    }
}
