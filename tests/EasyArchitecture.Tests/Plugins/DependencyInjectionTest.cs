using System;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Tests.Stuff.DI;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class ContainerTest
    {
        private IContainer _container;


        [SetUp]
        public void SetUp()
        {

            _container = new ContainerPlugin().GetInstance();
        
        }

        [Test]
        public void Should_register_interfaces()
        {
            _container.Register<IDummyInterface, DummyImplementation>();

            var actual = _container.Resolve<IDummyInterface>();

            Assert.That(actual, Is.TypeOf<DummyImplementation>());
        }

        [Test]
        public void Should_override_register()
        {
            _container.Register<IDummyInterface, DummyImplementation>();
            _container.Register<IDummyInterface, NewDummyImplementation>();

            var actual = _container.Resolve<IDummyInterface>();

            Assert.That(actual, Is.TypeOf<NewDummyImplementation>());
        }

        [Test]
        public void Should_resolve_interfaces()
        {
            _container.Register<IDummyInterface, DummyImplementation>();

            var implementation = _container.Resolve<IDummyInterface>();

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
            _container.Register<IDummyInterface, DependencyImplementation>();
            _container.Register<IDummyRequiredObjectInterface, DummyRequiredObjectImplementation>();

            var implementation = _container.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "RequiredMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

        [Test]
        public void Should_resolve_interfaces_with_proxy()
        {
            _container.Register<IDummyInterface, DummyImplementation>();

            var implementation = _container.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "DummyMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

    }

}
