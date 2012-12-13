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
        private readonly EasyConfig _easyConfig;

        internal ForExpression(string moduleName)
        {
            _easyConfig = new EasyConfig(moduleName);
        }

        public ForExpression Log()
        {
            return this;
        }

        public ForExpression Log(ILoggerPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ForExpression Log<T>() where T : ILoggerPlugin
        {
            _easyConfig.Register<ILoggerPlugin, T>();
            return this;
        }

        public ForExpression Translation()
        {
            return this;
        }

        public ForExpression Translation(ITranslatorPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ForExpression Translation<T>() where T : ITranslatorPlugin
        {
            _easyConfig.Register<ITranslatorPlugin,T>();
            return this;
        }

        public ForExpression Persistence()
        {
            return this;
        }

        public ForExpression Persistence(IPersistencePlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ForExpression Persistence<T>() where T : IPersistencePlugin
        {
            _easyConfig.Register<IPersistencePlugin, T>();
            return this;
        }

        public ForExpression DependencyInjection()
        {
            return this;
        }

        public ForExpression DependencyInjection(IIoCPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ForExpression DependencyInjection<T>() where T : IIoCPlugin
        {
            _easyConfig.Register<IIoCPlugin, T>();
            return this;
        }

        public ForExpression Validator()
        {
            return this;
        }

        public ForExpression Validator(IValidatorPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ForExpression Validator<T>() where T : IValidatorPlugin
        {
            _easyConfig.Register<IValidatorPlugin, T>();
            return this;
        }

        public ForExpression Cache()
        {
            return this;
        }

        public ForExpression Cache(ICachePlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ForExpression Cache<T>() where T : ICachePlugin
        {
            _easyConfig.Register<ICachePlugin, T>();
            return this;
        }

        public ForExpression Storage()
        {
            return this;
        }

        public ForExpression Storage(IStoragePlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ForExpression Storage<T>() where T : IStoragePlugin
        {
            _easyConfig.Register<IStoragePlugin, T>();
            return this;
        }

        public void Done()
        {
            _easyConfig.Start();
        }

    }
}