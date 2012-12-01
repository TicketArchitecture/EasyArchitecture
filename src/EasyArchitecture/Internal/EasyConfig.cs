using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Plugins;
using EasyArchitecture.Plugins.Default.DI;
using EasyArchitecture.Plugins.Default.Log;
using EasyArchitecture.Plugins.Default.Map;
using EasyArchitecture.Plugins.Default.Persistence;
using EasyArchitecture.Plugins.Default.Validation;

namespace EasyArchitecture.Internal
{
    internal class EasyConfig
    {
        internal string ModuleName { get; private set; }
        internal Assembly DomainAssembly;
        internal Assembly ApplicationAssembly;
        internal Assembly InfrastructureAssembly;

        internal Diagnostic.LogLevel LogLevel = Diagnostic.LogLevel.Fatal;

        internal readonly Dictionary<Type, object> Plugins = new Dictionary<Type, object>();

        internal Instances.Translator Translator;
        internal Instances.Logger Logger;
        internal Instances.PersistenceManager Persistence;
        internal Instances.DependencyInjection DependencyInjection;
        internal Instances.Validator Validator;

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
            if (!Plugins.ContainsKey(typeof(ILogPlugin)))
                Plugins[typeof(ILogPlugin)] = new LogPlugin();
            if (!Plugins.ContainsKey(typeof(IDependencyInjectionPlugin)))
                Plugins[typeof(IDependencyInjectionPlugin)] = new InjectionPlugin();
            if (!Plugins.ContainsKey(typeof( IObjectMapperPlugin)))
                Plugins[typeof(IObjectMapperPlugin)] = new ObjectMapperPlugin();
            if (!Plugins.ContainsKey(typeof(IValidatorPlugin)))
                Plugins[typeof(IValidatorPlugin)] = new ValidatorPlugin();

            //hey... im your father
            Translator = new Instances.Translator(this);
            Logger = new Instances.Logger(this);
            Persistence = new Instances.PersistenceManager(this);
            DependencyInjection = new Instances.DependencyInjection(this);
            Validator = new Instances.Validator(this);
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