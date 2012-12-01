using EasyArchitecture.Mechanisms;
using EasyArchitecture.Plugins;
using EasyArchitecture.Plugins.Default;
using EasyArchitecture.Plugins.Default.Log;
using EasyArchitecture.Plugins.Default.Map;
using EasyArchitecture.Plugins.Default.Persistence;
using EasyArchitecture.Plugins.Default.Validation;
using NUnit.Framework;

namespace EasyArchitecture.Tests.UserCode
{
    [TestFixture]
    public class ConfigurationTest
    {
        [Test]
        public void Should_use_default_plugins_if_no_configuration_are_specified()
        {
            Configuration
                .For("Application4Test")
                .Done();

            Verify();
        }

        [Test]
        public void Should_use_default_plugins_if_they_are_not_specified()
        {
            Configuration
                .For("Application4Test")
                    .Log()
                    .ObjectMapper()
                    .Persistence()
                    .DependencyInjection()
                    .Validator()
                    .Done();

            Verify();
        }

        [Test]
        public void Should_use_specified_plugins_implementations()
        {
            Configuration
                    .For("Application4Test")
                        .Log(new LogPlugin())
                        .ObjectMapper(new ObjectMapperPlugin())
                        .Persistence(new PersistencePlugin())
                        .DependencyInjection(new InjectionPlugin())
                        .Validator(new ValidatorPlugin())
                        .Done();

            Verify();
        }

        [Test]
        public void Should_use_specified_plugin_types()
        {
            Configuration
                .For("Application4Test")
                        .Log<LogPlugin>()
                        .ObjectMapper<ObjectMapperPlugin>()
                        .Persistence<PersistencePlugin>()
                        .DependencyInjection<InjectionPlugin>()
                        .Validator<ValidatorPlugin>()
                        .Done();
            Verify();
        }

        private static void Verify()
        {
            var logPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(ILogPlugin)];
            var objectMapperPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(IObjectMapperPlugin)];
            var persistencePlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(IPersistencePlugin)];
            var dependencyInjectionPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(IDependencyInjectionPlugin)];
            var validatorPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(IValidatorPlugin)];

            Assert.That(logPlugin, Is.TypeOf<LogPlugin>());
            Assert.That(objectMapperPlugin, Is.TypeOf<ObjectMapperPlugin>());
            Assert.That(persistencePlugin, Is.TypeOf<PersistencePlugin>());
            Assert.That(dependencyInjectionPlugin, Is.TypeOf<InjectionPlugin>());
            Assert.That(validatorPlugin, Is.TypeOf<ValidatorPlugin>());
        }
    }
}
