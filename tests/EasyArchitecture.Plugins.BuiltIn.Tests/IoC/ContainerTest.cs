using EasyArchitecture.Plugins.BultIn.IoC;
using EasyArchitecture.Plugins.Tests.IoC;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.IoC
{
    [TestFixture]
    public class ContainerTest:MinimalContainerTest
    {
        [SetUp]
        public override void SetUp()
        {
            Container = new ContainerPlugin().GetInstance();
        }
    }
}
