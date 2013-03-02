using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Caching;
using EasyArchitecture.Plugins.Contracts.IoC;
using EasyArchitecture.Plugins.Contracts.Log;
using EasyArchitecture.Plugins.Contracts.Persistence;
using EasyArchitecture.Plugins.Contracts.Storage;
using EasyArchitecture.Plugins.Contracts.Translation;
using EasyArchitecture.Plugins.Contracts.Validation;

namespace EasyArchitecture.Configuration.Expressions
{
    public class ForExpression
    {
        private readonly string _moduleName;
        private readonly PluginConfiguration _pluginConfiguration;

        internal ForExpression(string moduleName)
        {
            _moduleName = moduleName;
            _pluginConfiguration = PluginConfiguration.Create();
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
            InstanceProvider.Configure(_moduleName, _pluginConfiguration);
        }
    }
}