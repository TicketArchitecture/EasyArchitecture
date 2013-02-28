using EasyArchitecture.Mechanisms.Configuration.Exceptions;
using EasyArchitecture.Mechanisms.IoC;
using EasyArchitecture.Tests.IoC.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Tests.IoC
{
    [TestFixture]
    public class ContainerServiceTest
    {
        [Test]
        public void Should_throw_exception_when_resolve_called_whithout_configuration()
        {
            Assert.That(()=>Container.Resolve<IDogFacade>(), Throws.InstanceOf<NotConfiguredModuleException>());
        }
    }
}
