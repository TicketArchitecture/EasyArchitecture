using EasyArchitecture.Core;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.Contracts.Caching;
using EasyArchitecture.Plugin.Contracts.IoC;
using EasyArchitecture.Plugin.Contracts.Log;
using EasyArchitecture.Plugin.Contracts.Persistence;
using EasyArchitecture.Plugin.Contracts.Storage;
using EasyArchitecture.Plugin.Contracts.Translation;
using EasyArchitecture.Plugin.Contracts.Validation;

namespace EasyArchitecture.Mechanisms.Configuration.Expressions
{
    public class ForExpression
    {
        private readonly string _moduleName;
        private readonly PluginConfiguration _pluginConfiguration;

        internal ForExpression(string moduleName)
        {
            _moduleName = moduleName;
            _pluginConfiguration = new PluginConfiguration(moduleName);
        }

        public ForExpression Log(ILoggerPlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Log<T>() where T : ILoggerPlugin
        {
            _pluginConfiguration.Register<ILoggerPlugin, T>(); 
            return this;
        }

        public ForExpression Translation(ITranslatorPlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Translation<T>() where T : ITranslatorPlugin
        {
            _pluginConfiguration.Register<ITranslatorPlugin, T>();
            return this;
        }

        public ForExpression Persistence(IPersistencePlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Persistence<T>() where T : IPersistencePlugin
        {
            _pluginConfiguration.Register<IPersistencePlugin, T>();
            return this;
        }

        public ForExpression Container(IContainerPlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Container<T>() where T : IContainerPlugin
        {
            _pluginConfiguration.Register<IContainerPlugin, T>();
            return this;
        }

        public ForExpression Validator(IValidatorPlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Validator<T>() where T : IValidatorPlugin
        {
            _pluginConfiguration.Register<IValidatorPlugin, T>();
            return this;
        }

        public ForExpression Cache(ICachePlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Cache<T>() where T :ICachePlugin
        {
            _pluginConfiguration.Register<ICachePlugin, T>();
            return this;
        }

        public ForExpression Storage(IStoragePlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Storage<T>() where T : IStoragePlugin
        {
            _pluginConfiguration.Register<IStoragePlugin, T>();
            return this;
        }

        public void Done()
        {
            _pluginConfiguration.ModuleName = _moduleName;
            PluginConfigurationNormalizer.Normalize( _pluginConfiguration);
            var moduleConfiguration = FactoryInitializer.Exec(_pluginConfiguration);
            ModuleConfigurationList.Add(_moduleName, moduleConfiguration);
        }
    }
}