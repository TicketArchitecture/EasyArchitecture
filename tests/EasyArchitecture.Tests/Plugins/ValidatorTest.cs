using System;
using System.Reflection;
using Application4Test.Domain;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;
using EasyArchitecture.Tests.Stuff.Helpers;
using EasyArchitecture.Validation.Plugin.BultIn;
using EasyArchitecture.Validation.Plugin.Contracts;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class ValidatorTest
    {
        private Dog _oldDog;
        private Dog _youngDog;
        private IValidator _plugin;

        [SetUp]
        public void SetUp()
        {
            _oldDog = new Dog { Age = 15, Name = "Old Dog" };
            _youngDog = new Dog { Age = 5, Name = "Young Dog" };

            var _moduleName = Guid.NewGuid().ToString();

            var validatorPlugin = new ValidatorPlugin();
            PluginInspector pluginInspector;

            var infraAssembly = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.InfrastructureAssemblyName);

            validatorPlugin.Configure(new ModuleAssemblies(_moduleName, null, null, infraAssembly), out pluginInspector);
            _plugin = validatorPlugin.GetInstance();
        }

        [Test]
        public void Should_return_validation_messages_to_invalid_entity()
        {
            var expected = new System.Collections.Generic.List<string>() { "There's no dog so old" };
            var actual = _plugin.Validate(_oldDog);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_not_return_messages_valid_entity()
        {
            var expected = new System.Collections.Generic.List<string>();
            var actual = _plugin.Validate(_youngDog);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
