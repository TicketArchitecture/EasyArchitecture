using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Storage.Plugin.Contracts;
using EasyArchitecture.Translation.Plugin.Contracts;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Configuration.Expressions
{
    public class ForExpression
    {
        private readonly ModuleConfiguration _moduleConfiguration;

        internal ForExpression(string moduleName)
        {
            _moduleConfiguration = new ModuleConfiguration(moduleName);
        }

        public ForExpression Log()
        {
            return this;
        }

        public ForExpression Log(ILoggerPlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Log<T>() where T : ILoggerPlugin
        {
            _moduleConfiguration.Register<ILoggerPlugin, T>();
            return this;
        }

        public ForExpression Translation()
        {
            return this;
        }

        public ForExpression Translation(ITranslatorPlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Translation<T>() where T : ITranslatorPlugin
        {
            _moduleConfiguration.Register<ITranslatorPlugin,T>();
            return this;
        }

        public ForExpression Persistence()
        {
            return this;
        }

        public ForExpression Persistence(IPersistencePlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Persistence<T>() where T : IPersistencePlugin
        {
            _moduleConfiguration.Register<IPersistencePlugin, T>();
            return this;
        }

        public ForExpression DependencyInjection()
        {
            return this;
        }

        public ForExpression DependencyInjection(IIoCPlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            return this;
        }

        public ForExpression DependencyInjection<T>() where T : IIoCPlugin
        {
            _moduleConfiguration.Register<IIoCPlugin, T>();
            return this;
        }

        public ForExpression Validator()
        {
            return this;
        }

        public ForExpression Validator(IValidatorPlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Validator<T>() where T : IValidatorPlugin
        {
            _moduleConfiguration.Register<IValidatorPlugin, T>();
            return this;
        }

        public ForExpression Cache()
        {
            return this;
        }

        public ForExpression Cache(ICachePlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Cache<T>() where T : ICachePlugin
        {
            _moduleConfiguration.Register<ICachePlugin, T>();
            return this;
        }

        public ForExpression Storage()
        {
            return this;
        }

        public ForExpression Storage(IStoragePlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Storage<T>() where T : IStoragePlugin
        {
            _moduleConfiguration.Register<IStoragePlugin, T>();
            return this;
        }

        public void Done()
        {
            _moduleConfiguration.Start();
        }

    }
}