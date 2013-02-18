using EasyArchitecture.IoC;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Tests.IoC.Stuff;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.IoC
{
    [TestFixture]
    public class ContainerTest
    {
        private MockRepository _mockery;
        private IContainer _instancePlugin;

        [SetUp]
        public void Setup()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<IContainer>();

            LocalThreadStorage.SetInstance(new EasyArchitecture.IoC.Instance.Container(_instancePlugin));
        }

        [Test]
        [Ignore("Necessário rever forma como .Resolve inicializa")]
        public void Can_get_a_facade()
        {
            Expect.Call(() => _instancePlugin.Resolve<IDogFacade>());
            _mockery.ReplayAll();

            Container.Resolve<IDogFacade>();

            _mockery.VerifyAll();
        }

        [Test]
        public void Can_get_a_overrided_facade()
        {
            Expect.Call(() => _instancePlugin.Register<IDogFacade,DummyDogFacade>());
            _mockery.ReplayAll();

            Container.Register<IDogFacade, DummyDogFacade>();

            _mockery.VerifyAll();
        }
    }
}
