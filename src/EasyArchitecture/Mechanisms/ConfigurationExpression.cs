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

        public ConfigurationExpression Log(ILogPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression Log<T>() where T : ILogPlugin
        {
            _easyConfig.Register<ILogPlugin, T>();
            return this;
        }

        public ConfigurationExpression ObjectMapper()
        {
            return this;
        }

        public ConfigurationExpression ObjectMapper(IObjectMapperPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression ObjectMapper<T>() where T : IObjectMapperPlugin
        {
            _easyConfig.Register<IObjectMapperPlugin,T>();
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

        public ConfigurationExpression DependencyInjection(IDependencyInjectionPlugin plugin)
        {
            _easyConfig.Register(plugin);
            return this;
        }

        public ConfigurationExpression DependencyInjection<T>() where T : IDependencyInjectionPlugin
        {
            _easyConfig.Register<IDependencyInjectionPlugin, T>();
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

        public void Done()
        {
            _easyConfig.Start();
        }
    }
}