using EasyArchitecture.Plugin.BultIn.Storage;
using EasyArchitecture.Plugins.Validation.Storage;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Storage
{
    [TestFixture]
    public class StorageTest:MinimalStorageTest
    {
        [SetUp]
        public override void SetUp()
        {
            Storage = new StoragePlugin().GetInstance();
        }
    }
}
