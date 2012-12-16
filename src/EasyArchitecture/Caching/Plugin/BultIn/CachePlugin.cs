using System.Reflection;
using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Caching.Plugin.BultIn
{
    internal class CachePlugin : ICachePlugin
    {
        public void Configure(ModuleAssemblies moduleAssemblies)
        {
        }

        public ICache GetInstance()
        {
            return new Cache();
        }
    }
}
