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
using EasyArchitecture.Runtime;
using EasyArchitecture.Storage.Instance;
using EasyArchitecture.Storage.Plugin.BultIn;
using EasyArchitecture.Storage.Plugin.Contracts;
using EasyArchitecture.Translation.Instance;
using EasyArchitecture.Translation.Plugin.BultIn;
using EasyArchitecture.Translation.Plugin.Contracts;
using EasyArchitecture.Validation.Instance;
using EasyArchitecture.Validation.Plugin.BultIn;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Configuration.Instance
{
    internal class EasyConfig
    {
        internal string ModuleName { get; private set; }
        internal Assembly DomainAssembly;
        internal Assembly ApplicationAssembly;
        internal Assembly InfrastructureAssembly;

        internal LogLevel LogLevel = LogLevel.Fatal;

        internal readonly Dictionary<Type, object> Plugins = new Dictionary<Type, object>();

        internal Translator Translator;
        internal Logger Logger;
        internal PersistenceManager Persistence;
        internal ServiceLocator ServiceLocator;
        internal Validator Validator;
        internal Cache Cache;
        internal Storer Storage;

        internal EasyConfig(string moduleName)
        {
            ModuleName = moduleName;
        }

        internal void Start()
        {
            //load assemblies
            ApplicationAssembly = AssemblyManager.GetApplicationAssembly(ModuleName);
            DomainAssembly = AssemblyManager.GetDomainAssembly(ModuleName);
            InfrastructureAssembly = AssemblyManager.GetInfrastructureAssembly(ModuleName);

            //put yourself on config list
            EasyConfigurations.Configurations[this.ModuleName] = this;

            //set defaults
            if (!Plugins.ContainsKey(typeof(IPersistencePlugin)) )
                Plugins[typeof(IPersistencePlugin)] = new PersistencePlugin();
            if (!Plugins.ContainsKey(typeof(ILoggerPlugin)))
                Plugins[typeof(ILoggerPlugin)] = new LoggerPlugin();
            if (!Plugins.ContainsKey(typeof(IIoCPlugin)))
                Plugins[typeof(IIoCPlugin)] = new IocPlugin();
            if (!Plugins.ContainsKey(typeof( ITranslatorPlugin)))
                Plugins[typeof(ITranslatorPlugin)] = new TranslatorPlugin();
            if (!Plugins.ContainsKey(typeof(IValidatorPlugin)))
                Plugins[typeof(IValidatorPlugin)] = new ValidatorPlugin();
            if (!Plugins.ContainsKey(typeof(ICachePlugin)))
                Plugins[typeof(ICachePlugin)] = new CachePlugin();
            if (!Plugins.ContainsKey(typeof(IStoragePlugin)))
                Plugins[typeof(IStoragePlugin)] = new StoragePlugin();
            
            //hey... im your father
            Translator = new Translator(this);
            Logger = new Logger(this);
            Persistence = new PersistenceManager(this);
            ServiceLocator = new ServiceLocator(this);
            Validator = new Validator(this);
            Cache = new Cache(this);
            Storage = new Storer(this);
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