using EasyArchitecture.Plugins.Validation.Storage;
using EasyArchitecture.Storage.Plugin.BultIn;
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
