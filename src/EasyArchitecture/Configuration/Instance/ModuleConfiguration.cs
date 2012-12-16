using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Caching.Instance;
using EasyArchitecture.Caching.Plugin.BultIn;
using EasyArchitecture.Caching.Plugin.Contracts;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Log.Instance;
using EasyArchitecture.Log.Plugin.BultIn;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Persistence.Instance;
using EasyArchitecture.Persistence.Plugin.BultIn;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Storage.Instance;
using EasyArchitecture.Storage.Plugin.BultIn;
using EasyArchitecture.Storage.Plugin.Contracts;
using EasyArchitecture.Translation.Instance;
using EasyArchitecture.Translation.Plugin.BultIn;
using EasyArchitecture.Translation.Plugin.Contracts;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Configuration.Instance
{
    internal class ModuleConfiguration
    {
        internal string ModuleName { get; private set; }
        //TODO: remove
        internal Assembly DomainAssembly;
        internal Assembly ApplicationAssembly;
        internal Assembly InfrastructureAssembly;

        internal LogLevel LogLevel = LogLevel.Fatal;

        internal readonly Dictionary<Type, object> Plugins = new Dictionary<Type, object>();

        internal Translator Translator;
        internal Logger Logger;
        internal PersistenceManager Persistence;
        internal ServiceLocator ServiceLocator;
        internal ValidatorFactory ValidatorFactory;
        internal Cache Cache;
        internal Storer Storage;

        internal ModuleConfiguration(string moduleName)
        {
            ModuleName = moduleName;
        }

        internal void Start()
        {
            //---------------------------------
            // INIT MECHANISMS
            //---------------------------------


            

            //if (!Plugins.ContainsKey(typeof(IValidatorPlugin)))
            //    Plugins[typeof(IValidatorPlugin)] = new ValidatorPlugin();
            //ValidatorFactory = new ValidatorFactory(moduleAssemblies, (IValidatorPlugin)Plugins[typeof(IValidatorPlugin)]);
            //ValidatorFactory.RegisterPlugin(ModuleName, (IValidatorPlugin)Plugins[typeof(IValidatorPlugin)]);


            if (!Plugins.ContainsKey(typeof(ILoggerPlugin)))
                Plugins[typeof(ILoggerPlugin)] = new LoggerPlugin();
            Logger = new Logger(this);
            

            if (!Plugins.ContainsKey(typeof(ITranslatorPlugin)))
                Plugins[typeof(ITranslatorPlugin)] = new TranslatorPlugin();
            Translator = new Translator(this);


            if (!Plugins.ContainsKey(typeof(ICachePlugin)))
                Plugins[typeof(ICachePlugin)] = new CachePlugin();
            Cache = new Cache(this);
            
            if (!Plugins.ContainsKey(typeof(IStoragePlugin)))
                Plugins[typeof(IStoragePlugin)] = new StoragePlugin();
            Storage = new Storer(this);

            if (!Plugins.ContainsKey(typeof(IPersistencePlugin)))
                Plugins[typeof(IPersistencePlugin)] = new PersistencePlugin();
            Persistence = new PersistenceManager(this);

            if (!Plugins.ContainsKey(typeof(IIoCPlugin)))
                Plugins[typeof(IIoCPlugin)] = new IocPlugin();
            ServiceLocator = new ServiceLocator(this);


            //---------------------------------
            // SAVE CONFIG FOR MODULE -> GO
            //---------------------------------
            //put yourself on config list
            ConfigurationSelector.Configurations[this.ModuleName] = this;


        }

        internal void Register<T>(T plugin)
        {
            Plugins.Add(typeof(T), plugin);
        }

        internal void Register<TU, T>()
        {
            var type = typeof(T);
            var plugin = type.Assembly.CreateInstance(type.FullName);
            Register((TU)plugin);
        }

    }
}