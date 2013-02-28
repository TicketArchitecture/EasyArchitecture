using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Plugin.Contracts.Storage
{
    public interface IStoragePlugin : IInstanceProvider<IStorage>, IConfigurablePlugin
    {
    }
}
