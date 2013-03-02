using EasyArchitecture.Configuration.Exceptions;
using EasyArchitecture.Mechanisms.IoC;
using EasyArchitecture.Tests.Instances.IoC.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Instances.IoC
{
    [TestFixture]
    public class ContainerServiceTest
    {
        [Test]
        public void Should_throw_exception_when_resolve_called_whithout_configuration()
        {
            Assert.That(()=>Container.Resolve<IDogFacade>(), Throws.InstanceOf<NotConfiguredException>());
        }
    }
}
