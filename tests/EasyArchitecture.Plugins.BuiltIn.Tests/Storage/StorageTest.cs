using EasyArchitecture.Plugins.BultIn.Storage;
using EasyArchitecture.Plugins.Tests.Storage;
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
