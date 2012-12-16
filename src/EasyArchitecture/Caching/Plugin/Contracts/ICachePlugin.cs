using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Caching.Plugin.Contracts
{
    public interface ICachePlugin : IConfigurablePlugin, IInstanceProvider<ICache>
    {
    }
}