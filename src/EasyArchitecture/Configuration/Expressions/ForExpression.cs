using System;
using System.Collections.Generic;
using EasyArchitecture.Caching.Plugin.BultIn;
using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Log.Plugin.BultIn;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Persistence.Plugin.BultIn;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Storage.Plugin.BultIn;
using EasyArchitecture.Storage.Plugin.Contracts;
using EasyArchitecture.Translation.Plugin.BultIn;
using EasyArchitecture.Translation.Plugin.Contracts;
using EasyArchitecture.Validation.Instance;
using EasyArchitecture.Validation.Plugin.BultIn;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Configuration.Expressions
{
    public class ForExpression
    {
        private readonly ModuleConfiguration _moduleConfiguration;
        private readonly ConfigHelper _configHelper;

        internal ForExpression(string moduleName)
        {
            _moduleConfiguration = new ModuleConfiguration(moduleName);
             _configHelper = new ConfigHelper();
        }

        public ForExpression Log(ILoggerPlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Log<T>() where T : ILoggerPlugin
        {
            _moduleConfiguration.Register<ILoggerPlugin, T>();
            _configHelper.Register<ILoggerPlugin, T>(); 
            return this;
        }

        public ForExpression Translation(ITranslatorPlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Translation<T>() where T : ITranslatorPlugin
        {
            _moduleConfiguration.Register<ITranslatorPlugin,T>();
            _configHelper.Register<ITranslatorPlugin, T>();
            return this;
        }

        public ForExpression Persistence(IPersistencePlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Persistence<T>() where T : IPersistencePlugin
        {
            _moduleConfiguration.Register<IPersistencePlugin, T>();
            _configHelper.Register<IPersistencePlugin, T>();
            return this;
        }

        public ForExpression DependencyInjection(IIoCPlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression DependencyInjection<T>() where T : IIoCPlugin
        {
            _moduleConfiguration.Register<IIoCPlugin, T>();
            _configHelper.Register<IIoCPlugin, T>();
            return this;
        }

        public ForExpression Validator(IValidatorInstance plugin)
        {
            _moduleConfiguration.Register(plugin);
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Validator<T>() where T : IValidatorInstance
        {
            _moduleConfiguration.Register<IValidatorInstance, T>();
            _configHelper.Register<IValidatorInstance, T>();
            return this;
        }

        public ForExpression Cache(ICachePlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Cache<T>() where T : ICachePlugin
        {
            _moduleConfiguration.Register<ICachePlugin, T>();
            _configHelper.Register<ICachePlugin, T>();
            return this;
        }

        public ForExpression Storage(IStoragePlugin plugin)
        {
            _moduleConfiguration.Register(plugin);
            _configHelper.Register(plugin);
            return this;
        }

        public ForExpression Storage<T>() where T : IStoragePlugin
        {
            _moduleConfiguration.Register<IStoragePlugin, T>();
            _configHelper.Register<IStoragePlugin, T>();
            return this;
        }

        public void Done()
        {
            //_moduleConfiguration.Start();
            //_configHelper.Start();
            ModuleConfigurationNormalizer.Normalize( _configHelper);
            FactoryInitializer.Exec(_configHelper);

            
        }

    }

    public static class FactoryInitializer
    {
        private static readonly List<Type> AllowedFactories=new List<Type>();
        private static readonly Dictionary<Type, Type> BuiltinPlugins = new Dictionary<Type, Type>();

        static FactoryInitializer()
        {
            //TODO: load all types that implements 2 required interfaces
            AllowedFactories.Add(typeof(ValidatorFactory));
        }

        public static void Exec(ConfigHelper configHelper)
        {
            foreach (var allowedFactory in AllowedFactories)
            {
                var factory = (IRegisterablePluginFactory) Activator.CreateInstance(allowedFactory);
                factory.RegisterPlugin(configHelper);
            }
        }
    }

    public static class ModuleConfigurationNormalizer
    {
        private static readonly Dictionary<Type, Type> BuiltinPlugins = new Dictionary<Type, Type>();

        static ModuleConfigurationNormalizer()
        {
            BuiltinPlugins.Add(typeof (IValidatorPlugin), typeof (ValidatorPlugin));
            BuiltinPlugins.Add(typeof (ILoggerPlugin), typeof (LoggerPlugin));
            BuiltinPlugins.Add(typeof (ITranslatorPlugin), typeof (TranslatorPlugin));
            BuiltinPlugins.Add(typeof (ICachePlugin), typeof (CachePlugin));
            BuiltinPlugins.Add(typeof (IStoragePlugin), typeof (StoragePlugin));
            BuiltinPlugins.Add(typeof (IPersistencePlugin), typeof (PersistencePlugin));
            BuiltinPlugins.Add(typeof(IIoCPlugin), typeof(IocPlugin));
        }

        public static void Normalize( ConfigHelper configHelper)
        {
            var configuredPlugins =  configHelper.GetConfiguredPlugins();

            //complete configuration
            foreach (var builtinPlugin in BuiltinPlugins)
            {
                if(!configuredPlugins.ContainsKey(builtinPlugin.Key))
                {
                    var plugin = Activator.CreateInstance(builtinPlugin.Value);
                    configHelper.Register(plugin);
                }
            }

            
        }
    }

    public class ConfigHelper
    {
        //TODO: rename to moduleconfiguration
        private readonly Dictionary<Type, object> _plugins = new Dictionary<Type, object>();

        internal void Register<T>(T plugin)
        {
            _plugins.Add(typeof(T), plugin);
        }

        internal void Register<TU, T>()
        {
            var type = typeof(T);
            var plugin = type.Assembly.CreateInstance(type.FullName);
            Register((TU)plugin);
        }

        public Dictionary<Type, object> GetConfiguredPlugins()
        {
            return _plugins;
        }

        public T GetPlugin<T>()
        {
            return (T) _plugins[typeof(T)];
        }
    }
}