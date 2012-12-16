using System.Reflection;
using Application4Test.Domain;
using EasyArchitecture.Tests.Stuff.Helpers;
using EasyArchitecture.Validation.Plugin.BultIn;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class ValidatorTest
    {
        private Dog _oldDog;
        private Dog _youngDog;
        private Validator _plugin;

        [SetUp]
        public void SetUp()
        {
            _oldDog = new Dog { Age = 15, Name = "Old Dog" };
            _youngDog = new Dog { Age = 5, Name = "Young Dog" };

            //_plugin = new Validator();
        }

        [Test]
        public void Should_not_return_messages_for_invalid_entity_if_not_configurated()
        {
            var expected = new System.Collections.Generic.List<string>();
            var actual = _plugin.Validate(_oldDog);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("changes on plugin")]
        public void Should_return_validation_messages_to_invalid_entity()
        {
            //_plugin.Configure(AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.InfrastructureAssemblyName));

            var expected = new System.Collections.Generic.List<string>() { "There's no dog so old" };
            var actual = _plugin.Validate(_oldDog);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("changes on plugin")]
        public void Should_not_return_messages_valid_entity()
        {
            //_plugin.Configure(AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.InfrastructureAssemblyName));

            var expected = new System.Collections.Generic.List<string>();
            var actual = _plugin.Validate(_youngDog);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
