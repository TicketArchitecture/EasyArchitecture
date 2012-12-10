using EasyArchitecture.Mechanisms;
using EasyArchitecture.Plugins;
using EasyArchitecture.Plugins.Default.DI;
using EasyArchitecture.Plugins.Default.Log;
using EasyArchitecture.Plugins.Default.Persistence;
using EasyArchitecture.Plugins.Default.Translation;
using EasyArchitecture.Plugins.Default.Validation;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Mechanisms
{
    [TestFixture]
    public class ConfigurationTest
    {
        [Test]
        public void Should_use_default_plugins_if_no_configuration_are_specified()
        {
            Configure
                .For("Application4Test")
                .Done();

            Verify();
        }

        [Test]
        public void Should_use_a_type_of_module_instead_module_name_to_configure()
        {
            Configure
                .For<Application4Test.Application.Contracts.IDogFacade>()
                .Done();

            Verify();
        }

        [Test]
        public void Should_use_default_plugins_if_they_are_not_specified()
        {
            Configure
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
            Configure
                    .For("Application4Test")
                        .Log(new LoggerPlugin())
                        .ObjectMapper(new TranslatorPlugin())
                        .Persistence(new PersistencePlugin())
                        .DependencyInjection(new InjectionPlugin())
                        .Validator(new ValidatorPlugin())
                        .Done();

            Verify();
        }

        [Test]
        public void Should_use_specified_plugin_types()
        {
            Configure
                .For("Application4Test")
                        .Log<LoggerPlugin>()
                        .ObjectMapper<TranslatorPlugin>()
                        .Persistence<PersistencePlugin>()
                        .DependencyInjection<InjectionPlugin>()
                        .Validator<ValidatorPlugin>()
                        .Done();
            Verify();
        }

        private static void Verify()
        {
            var logPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(ILoggerPlugin)];
            var objectMapperPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(ITranslatorPlugin)];
            var persistencePlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(IPersistencePlugin)];
            var dependencyInjectionPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(IDependencyInjectionPlugin)];
            var validatorPlugin = Internal.EasyConfigurations.Configurations["Application4Test"].Plugins[typeof(IValidatorPlugin)];

            Assert.That(logPlugin, Is.TypeOf<LoggerPlugin>());
            Assert.That(objectMapperPlugin, Is.TypeOf<TranslatorPlugin>());
            Assert.That(persistencePlugin, Is.TypeOf<PersistencePlugin>());
            Assert.That(dependencyInjectionPlugin, Is.TypeOf<InjectionPlugin>());
            Assert.That(validatorPlugin, Is.TypeOf<ValidatorPlugin>());
        }
    }
}
