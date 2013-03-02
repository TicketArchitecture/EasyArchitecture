using System;
using EasyArchitecture.Plugin.Contracts.IoC;
using EasyArchitecture.Plugins.Tests.IoC.Stuff;
using NUnit.Framework;
using System.Collections.Generic;

namespace EasyArchitecture.Plugins.Tests.IoC
{
    [TestFixture]
    public abstract class MinimalContainerTest
    {
        protected IContainer Container;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_register_interfaces()
        {
            Container.Register<IDummyInterface, DummyImplementation>();

            var actual = Container.Resolve<IDummyInterface>();

            Assert.That(actual, Is.TypeOf<DummyImplementation>());
        }

        [Test]
        public void Should_override_register()
        {
            Container.Register<IDummyInterface, DummyImplementation>();
            Container.Register<IDummyInterface, NewDummyImplementation>();

            var actual = Container.Resolve<IDummyInterface>();

            Assert.That(actual, Is.TypeOf<NewDummyImplementation>());
        }

        [Test]
        public void Should_resolve_interfaces()
        {
            Container.Register<IDummyInterface, DummyImplementation>();

            var implementation = Container.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "DummyMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

        [Test]
        public void Should_resolve_dependencies()
        {
            Container.Register<IDummyInterface, DependencyImplementation>();
            Container.Register<IDummyRequiredObjectInterface, DummyRequiredObjectImplementation>();

            var implementation = Container.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "RequiredMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

        [Test]
        public void Should_resolve_interfaces_with_proxy()
        {
            Container.Register<IDummyInterface, DummyImplementation>();

            var implementation = Container.Resolve<IDummyInterface>();

            Assert.That(implementation, Is.AssignableTo<IDummyInterface>());

            var methodReturn = implementation.DummyMethod();
            const string expectedMethodReturn = "DummyMethod";

            Assert.That(methodReturn, Is.EqualTo(expectedMethodReturn));
        }

        [Test]
        [Ignore("nao pode ser testado sem comentar a sequencia de interceptadores em InterceptionHook.cs")]
        public void Proxy_should_return_original_exception()
        {
            Container.Register(typeof(IDummyInterface),typeof(NewDummyImplementation),true);

            var implementation = Container.Resolve<IDummyInterface>();

            Assert.That(()=>implementation.VoidDummyMethod(), Throws.InstanceOf<NotImplementedException>());
        }

        [Test]
        public void Should_be_possible_call_void_facade_methods()
        {
            Container.Register<IDummyInterface, DummyImplementation>();

            var implementation = Container.Resolve<IDummyInterface>();
            const string voidmethodmessage = "VoidDummyMethodExecuted";

            implementation.VoidDummyMethod();
            Assert.That(implementation.Message(), Is.EqualTo(voidmethodmessage));
        }

        [Test]
        public void Should_be_possible_call_facade_methods_containing_primitive_type_arg_and_return()
        {
            Container.Register<IDummyInterface, DummyImplementation>();
            var implementation = Container.Resolve<IDummyInterface>();

            const int expectedInt = 1;
            Assert.That(implementation.PrimitiveWithOneArg(1), Is.EqualTo(expectedInt));
        

        }

        [Test]
        public void Should_be_possible_call_facade_methods_containing_two_primitive_type_args()
        {
            Container.Register<IDummyInterface, DummyImplementation>();
            var implementation = Container.Resolve<IDummyInterface>();

            string expectedStr = "message1+message2";
            Assert.That(implementation.withArgs("message1+", "message2"), Is.EqualTo(expectedStr));
        }

        [Test]
        public void Should_be_possible_call_facade_methods_containing_generic_type_return_and_user_defined_class_arg()
        {
            Container.Register<IDummyInterface, DummyImplementation>();
            var implementation = Container.Resolve<IDummyInterface>();

            var kvp = new KeyValuePair<int, DummyClass>(1, new DummyClass());
            Assert.That(implementation.WithTypedInterfaceArg(kvp), Is.EqualTo(kvp.Value.GetType()));
        }

        [Test]
        public void Should_be_possible_call_facade_methods_containing_enum_arg_and_return()
        {
            Container.Register<IDummyInterface, DummyImplementation>();
            var implementation = Container.Resolve<IDummyInterface>();

            Assert.That(implementation.EnumWithEnumArg(DummyEnum.Second), Is.EqualTo(DummyEnum.Second));
        }


        [Test]
        public void Should_be_possible_call_facade_methods_containing_array_arg_and_return()
        {
            Container.Register<IDummyInterface, DummyImplementation>();
            var implementation = Container.Resolve<IDummyInterface>();

            string[] expectedArr = { "message1", "message2" };
            string[] strArr = { "message1", "message2" };

            var returnedStrArr = implementation.ArrayWithArrArg(strArr);
            Assert.That(returnedStrArr, Is.EqualTo(expectedArr));
        }

        [Test]
        public void Should_be_possible_call_facade_methods_containing_generic_return_with_user_defined_type()
        {

            Container.Register<IDummyInterface, DummyImplementation>();
            var implementation = Container.Resolve<IDummyInterface>();

            IList<DummyClass> expectedLst = new List<DummyClass>();
            expectedLst.Add(new DummyClass());

            var actualLst = implementation.TypedInterfaceWithoutArgs();

            Assert.That(actualLst, Is.EqualTo(expectedLst));
        }
    }
}
