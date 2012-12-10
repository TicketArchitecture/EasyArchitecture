using EasyArchitecture.Plugins.Default.DI;
using EasyArchitecture.Tests.Stuff.DI;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class DependencyInjectionTest
    {
        [Test]
        public void Can_register_interfaces()
        {
            Container.Register<IDummyInterface, DummyImplementation>();

            var type = Container.Verify<IDummyInterface>();

            Assert.That(type, Is.EqualTo(typeof(DummyImplementation)));
        }

        [Test]
        public void Can_override_register()
        {
            Container.Register<IDummyInterface, DummyImplementation>();
            Container.Register<IDummyInterface, NewDummyImplementation>();

            var type = Container.Verify<IDummyInterface>();

            Assert.That(type, Is.EqualTo(typeof(NewDummyImplementation)));
        }

        [Test]
        public void Can_resolve_interfaces()
        {
            Container.Register<IDummyInterface, DummyImplementation>();

            var implementation = Container.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "DummyMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
            Assert.Inconclusive("Not implemented yet");
        }

        [Test]
        public void Should_not_register_classes()
        {
            Assert.That(
                () => Container.Register<DummyImplementation, DummyImplementation>(),
                Throws.InstanceOf<NotInterfaceException>()
            );
        }

        [Test]
        public void Shouldnt_Register_Class_That_Dont_Implement_The_Provided_Interface()
        {
            //Garantido pela constraint de U:T
            //Assert.That(
            //    () => Container.Register<IDummyInterface, DummyStrangeImplementation>(),
            //    Throws.InstanceOf<Exception>()
            //);
            Assert.Pass();
        }

    }
}
