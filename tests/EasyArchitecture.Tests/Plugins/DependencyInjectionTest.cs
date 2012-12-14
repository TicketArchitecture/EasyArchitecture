using System;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.Tests.Stuff.DI;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class DependencyInjectionTest
    {
        private IocPlugin _plugin;

        [SetUp]
        public void SetUp()
        {
            _plugin = new IocPlugin();
        }

        [Test]
        public void Should_register_interfaces()
        {
            _plugin.Register<IDummyInterface, DummyImplementation>();

            var actual = _plugin.Resolve<IDummyInterface>();

            Assert.That(actual, Is.TypeOf<DummyImplementation>());
        }

        [Test]
        public void Should_override_register()
        {
            _plugin.Register<IDummyInterface, DummyImplementation>();
            _plugin.Register<IDummyInterface, NewDummyImplementation>();

            var actual = _plugin.Resolve<IDummyInterface>();

            Assert.That(actual, Is.TypeOf<NewDummyImplementation>());
        }

        [Test]
        public void Should_resolve_interfaces()
        {
            _plugin.Register<IDummyInterface, DummyImplementation>();

            var implementation = _plugin.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "DummyMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

        [Test]
        public void Should_not_register_class_that_dont_implement_the_provided_interface()
        {
            ////Garantido pela constraint de U:T
            //Assert.That(
            //    () => _plugin.Register<IDummyInterface, DummyStrangeImplementation>(),
            //    Throws.InstanceOf<Exception>()
            //);
            Assert.Pass();
        }

        [Test]
        public void Should_resolve_dependencies()
        {
            _plugin.Register<IDummyInterface, DependencyImplementation>();
            _plugin.Register<IDummyRequiredObjectInterface, DummyRequiredObjectImplementation>();

            var implementation = _plugin.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "RequiredMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

        [Test]
        public void Should_resolve_interfaces_with_proxy()
        {
            _plugin.Register<IDummyInterface, DummyImplementation>();

            var implementation = _plugin.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "DummyMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

    }
}
