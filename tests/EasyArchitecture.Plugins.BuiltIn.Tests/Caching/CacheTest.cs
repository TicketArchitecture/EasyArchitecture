using EasyArchitecture.Plugin.BultIn.Caching;
using EasyArchitecture.Plugins.Tests.Caching;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Caching
{
    [TestFixture]
    public class CacheTest:MinimalCacheTest
    {
        [SetUp]
        public override void SetUp()
        {
            Cache =  new CachePlugin().GetInstance();
        }
    }
}