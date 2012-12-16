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
        private readonly ConfigHelper _configHelper;

        internal ForExpression(string moduleName)
        {
             _configHelper = new ConfigHelper();
        }

        public ForExpression Log(ILoggerPlugin plugin)
        {
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Log<T>() where T : ILoggerPlugin
        {
            _configHelper.Register<ILoggerPlugin, T>(); 
            return this;
        }

        public ForExpression Translation(ITranslatorPlugin plugin)
        {
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Translation<T>() where T : ITranslatorPlugin
        {
            _configHelper.Register<ITranslatorPlugin, T>();
            return this;
        }

        public ForExpression Persistence(IPersistencePlugin plugin)
        {
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Persistence<T>() where T : IPersistencePlugin
        {
            _configHelper.Register<IPersistencePlugin, T>();
            return this;
        }

        public ForExpression DependencyInjection(IIoCPlugin plugin)
        {
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression DependencyInjection<T>() where T : IIoCPlugin
        {
            _configHelper.Register<IIoCPlugin, T>();
            return this;
        }

        public ForExpression Validator(IValidator plugin)
        {
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Validator<T>() where T : IValidator
        {
            _configHelper.Register<IValidator, T>();
            return this;
        }

        public ForExpression Cache(ICachePlugin plugin)
        {
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Cache<T>() where T : ICachePlugin
        {
            _configHelper.Register<ICachePlugin, T>();
            return this;
        }

        public ForExpression Storage(IStoragePlugin plugin)
        {
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Storage<T>() where T : IStoragePlugin
        {
            _configHelper.Register<IStoragePlugin, T>();
            return this;
        }

        public void Done()
        {
            ModuleConfigurationNormalizer.Normalize( _configHelper);
            FactoryInitializer.Exec(_configHelper);
        }
    }
}