//using EasyArchitecture.Caching.Plugin.BultIn;
//using EasyArchitecture.Caching.Plugin.Contracts;
//using EasyArchitecture.Configuration;
//using EasyArchitecture.Configuration.Exceptions;
//using EasyArchitecture.Configuration.Instance;
//using EasyArchitecture.IoC.Plugin.BultIn;
//using EasyArchitecture.IoC.Plugin.Contracts;
//using EasyArchitecture.Log.Plugin.BultIn;
//using EasyArchitecture.Log.Plugin.Contracts;
//using EasyArchitecture.Persistence.Plugin.BultIn;
//using EasyArchitecture.Persistence.Plugin.Contracts;
//using EasyArchitecture.Runtime;
//using EasyArchitecture.Storage.Plugin.BultIn;
//using EasyArchitecture.Storage.Plugin.Contracts;
//using EasyArchitecture.Translation.Plugin.BultIn;
//using EasyArchitecture.Translation.Plugin.Contracts;
//using EasyArchitecture.Validation.Plugin.BultIn;
//using EasyArchitecture.Validation.Plugin.Contracts;
//using NUnit.Framework;

//namespace EasyArchitecture.Tests.Mechanisms
//{
//    [TestFixture]
//    public class ConfigurationTest
//    {
//        private string _moduleName= "Application4Test";

//        [Test]
//        public void Should_use_default_plugins_if_no_configuration_are_specified()
//        {
//            Configure
//                .For(_moduleName)
//                .Done();

//            Verify();
//        }


//        [Test]
//        public void Should_not_find_configuration_instance()
//        {
//            LocalThreadStorage.SetCurrentModuleName("None");
//            Assert.That(() => ModuleConfigurationList.Get(_moduleName), Throws.TypeOf<NotConfiguredModuleException>());
//        }

//        [Test]
//        public void Should_use_a_type_of_module_instead_module_name_to_configure()
//        {
//            Configure
//                .For<Application4Test.Application.Contracts.IDogFacade>()
//                .Done();

//            Verify();
//        }

//        [Test]
//        public void Should_use_specified_plugins_implementations()
//        {
//            Configure
//                .For(_moduleName)
//                    .Log(new LoggerPlugin())
//                    .Translation(new TranslatorPlugin())
//                    .Persistence(new PersistencePlugin())
//                    .Container(new ContainerPlugin())
//                    .Cache(new CachePlugin())
//                    .Storage(new StoragePlugin())
//                    .Validator(new ValidatorPlugin())
//                    .Done();

//            Verify();
//        }

//        [Test]
//        public void Should_use_specified_plugin_types()
//        {
//            Configure
//                .For(_moduleName)
//                    .Log<LoggerPlugin>()
//                    .Translation<TranslatorPlugin>()
//                    .Persistence<PersistencePlugin>()
//                    .Container<ContainerPlugin>()
//                    .Cache<CachePlugin>()
//                    .Storage<StoragePlugin>()
//                    .Validator<ValidatorPlugin>()
//                    .Done();

//            Verify();
//        }

//        private static void Verify()
//        {
//            ModuleConfigurationList.Get(_moduleName).Factories.ContainsKey(typeof()).

//            //var loggerPlugin = ConfigurationSelector.Configurations["Application4Test"].Plugins[typeof(ILoggerPlugin)];
//            //var translatorPlugin = ConfigurationSelector.Configurations["Application4Test"].Plugins[typeof(ITranslatorPlugin)];
//            //var persistencePlugin = ConfigurationSelector.Configurations["Application4Test"].Plugins[typeof(IPersistencePlugin)];
//            //var containerPlugin = ConfigurationSelector.Configurations["Application4Test"].Plugins[typeof(IContainerPlugin)];
//            //var validatorPlugin = ConfigurationSelector.Configurations["Application4Test"].Plugins[typeof(IValidatorPlugin)];
//            //var cachePlugin = ConfigurationSelector.Configurations["Application4Test"].Plugins[typeof(ICachePlugin)];
//            //var storagePlugin = ConfigurationSelector.Configurations["Application4Test"].Plugins[typeof(IStoragePlugin)];

//            //Assert.That(loggerPlugin, Is.TypeOf<LoggerPlugin>());
//            //Assert.That(translatorPlugin, Is.TypeOf<TranslatorPlugin>());
//            //Assert.That(persistencePlugin, Is.TypeOf<PersistencePlugin>());
//            //Assert.That(containerPlugin, Is.TypeOf<ContainerPlugin>());
//            //Assert.That(validatorPlugin, Is.TypeOf<Validator>());
//            //Assert.That(cachePlugin, Is.TypeOf<Cache>());
//            //Assert.That(storagePlugin, Is.TypeOf<StoragePlugin>());
//        }
//    }
//}
