using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Mechanisms
{
    public class ConfigurationExpression
    {
        private readonly EasyConfig _easyConfig;

        internal ConfigurationExpression(string moduleName)
        {
            _easyConfig = new EasyConfig(moduleName);
        }

        public ConfigurationExpression Log()
        {
            return this;
        }

        public ConfigurationExpression Log(ILoggerPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression Log<T>() where T : ILoggerPlugin
        {
            _easyConfig.Register<ILoggerPlugin, T>();
            return this;
        }

        public ConfigurationExpression ObjectMapper()
        {
            return this;
        }

        public ConfigurationExpression ObjectMapper(ITranslatorPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression ObjectMapper<T>() where T : ITranslatorPlugin
        {
            _easyConfig.Register<ITranslatorPlugin,T>();
            return this;
        }

        public ConfigurationExpression Persistence()
        {
            return this;
        }

        public ConfigurationExpression Persistence(IPersistencePlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression Persistence<T>() where T : IPersistencePlugin
        {
            _easyConfig.Register<IPersistencePlugin, T>();
            return this;
        }

        public ConfigurationExpression DependencyInjection()
        {
            return this;
        }

        public ConfigurationExpression DependencyInjection(IIoCPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression DependencyInjection<T>() where T : IIoCPlugin
        {
            _easyConfig.Register<IIoCPlugin, T>();
            return this;
        }

        public ConfigurationExpression Validator()
        {
            return this;
        }

        public ConfigurationExpression Validator(IValidatorPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression Validator<T>() where T : IValidatorPlugin
        {
            _easyConfig.Register<IValidatorPlugin, T>();
            return this;
        }

        public ConfigurationExpression Cache()
        {
            return this;
        }

        public ConfigurationExpression Cache(ICachePlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression Cache<T>() where T : ICachePlugin
        {
            _easyConfig.Register<ICachePlugin, T>();
            return this;
        }

        public ConfigurationExpression Storage()
        {
            return this;
        }

        public ConfigurationExpression Storage(IStoragePlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression Storage<T>() where T : IStoragePlugin
        {
            _easyConfig.Register<IStoragePlugin, T>();
            return this;
        }

        public ConfigurationExpression Resource()
        {
            return this;
        }

        public ConfigurationExpression Resource(IResourcePlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression Resource<T>() where T : IResourcePlugin
        {
            _easyConfig.Register<IResourcePlugin, T>();
            return this;
        }


        public void Done()
        {
            _easyConfig.Start();
        }

    }
}