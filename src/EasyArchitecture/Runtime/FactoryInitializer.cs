using System;
using System.Collections.Generic;
using EasyArchitecture.Caching.Instance;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.Log.Instance;
using EasyArchitecture.Persistence.Instance;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Storage.Instance;
using EasyArchitecture.Translation.Instance;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Runtime
{
    public static class FactoryInitializer
    {
        //private static readonly List<Type> AllowedFactories=new List<Type>();
        private static readonly Dictionary<Type,Type> AllowedFactories = new Dictionary<Type, Type>();
 
        static FactoryInitializer()
        {
            //TODO: load all types that implements 2 required interfaces
            AllowedFactories.Add(typeof(Validator), typeof(ValidatorFactory));
            AllowedFactories.Add(typeof(Cache), typeof(CacheFactory));
            AllowedFactories.Add(typeof(Translator), typeof(TranslatorFactory));
            AllowedFactories.Add(typeof(Logger), typeof(LoggerFactory));
            AllowedFactories.Add(typeof(Storer), typeof(StorerFactory));
            AllowedFactories.Add(typeof(Container), typeof(ContainerFactory));
            AllowedFactories.Add(typeof(Persistence.Instance.Persistence), typeof(PersistenceFactory));
        }

        public static ModuleConfiguration Exec(PluginConfiguration pluginConfiguration)
        {
            var moduleConfiguration = new ModuleConfiguration();

            //
            var moduleAssemblies = AssemblyManager.GetModuleAssemblies(pluginConfiguration.ModuleName);

            foreach (var allowedFactory in AllowedFactories)
            {
                var factory = (IConfigurableFactory) Activator.CreateInstance(allowedFactory.Value,moduleAssemblies);
                factory.Configure(pluginConfiguration);
                moduleConfiguration.Factories.Add(allowedFactory.Key,factory);
            }

            return moduleConfiguration;
        }
    }
}