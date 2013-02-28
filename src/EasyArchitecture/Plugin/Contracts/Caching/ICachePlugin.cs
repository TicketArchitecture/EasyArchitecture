using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Plugin.Contracts.Caching
{
    public interface ICachePlugin : IConfigurablePlugin, IInstanceProvider<ICache>
    {
    }
}