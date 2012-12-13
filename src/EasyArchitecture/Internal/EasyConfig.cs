using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Common.Diagnostic;
using EasyArchitecture.Plugins;
using EasyArchitecture.Plugins.BuiltIn.Cache;
using EasyArchitecture.Plugins.BuiltIn.IoC;
using EasyArchitecture.Plugins.BuiltIn.Log;
using EasyArchitecture.Plugins.BuiltIn.Persistence;
using EasyArchitecture.Plugins.BuiltIn.Resource;
using EasyArchitecture.Plugins.BuiltIn.Storage;
using EasyArchitecture.Plugins.BuiltIn.Translation;
using EasyArchitecture.Plugins.BuiltIn.Validation;

namespace EasyArchitecture.Internal
{
    internal class EasyConfig
    {
        internal string ModuleName { get; private set; }
        internal Assembly DomainAssembly;
        internal Assembly ApplicationAssembly;
        internal Assembly InfrastructureAssembly;

        internal LogLevel LogLevel = LogLevel.Fatal;

        internal readonly Dictionary<Type, object> Plugins = new Dictionary<Type, object>();

        internal Instances.Translator Translator;
        internal Instances.Logger Logger;
        internal Instances.PersistenceManager Persistence;
        internal Instances.DependencyInjection DependencyInjection;
        internal Instances.Validator Validator;
        internal Instances.Cache Cache;
        internal Instances.Storage Storage;
        internal Instances.Resource Resource;

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
            if (!Plugins.ContainsKey(typeof(ICachePlugin)))
                Plugins[typeof(IStoragePlugin)] = new StoragePlugin();
            if (!Plugins.ContainsKey(typeof(ICachePlugin)))
                Plugins[typeof(IResourcePlugin)] = new ResourcePlugin();
            
            //hey... im your father
            Translator = new Instances.Translator(this);
            Logger = new Instances.Logger(this);
            Persistence = new Instances.PersistenceManager(this);
            DependencyInjection = new Instances.DependencyInjection(this);
            Validator = new Instances.Validator(this);
            Cache = new Instances.Cache(this);
            Storage = new Instances.Storage(this);
            Resource = new Instances.Resource(this);
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