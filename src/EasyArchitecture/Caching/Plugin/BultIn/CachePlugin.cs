using System.Reflection;
using EasyArchitecture.Caching.Plugin.Contracts;

namespace EasyArchitecture.Caching.Plugin.BultIn
{
    internal class CachePlugin : ICachePlugin
    {
        public void Configure(Assembly assembly)
        {
        }

        public ICache GetInstance()
        {
            return new Cache();
        }
    }
}
