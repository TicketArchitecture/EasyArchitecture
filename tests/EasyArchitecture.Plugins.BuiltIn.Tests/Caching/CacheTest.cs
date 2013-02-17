using EasyArchitecture.Caching.Plugin.BultIn;
using EasyArchitecture.Plugins.Validation.Caching;
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