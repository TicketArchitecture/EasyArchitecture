using System;
using System.Collections.Generic;
using EasyArchitecture.Caching.Instance;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Log.Instance;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Storage.Instance;
using EasyArchitecture.Translation.Instance;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Runtime
{
    public static class FactoryInitializer
    {
        private static readonly List<Type> AllowedFactories=new List<Type>();
 
        static FactoryInitializer()
        {
            //TODO: load all types that implements 2 required interfaces
            AllowedFactories.Add(typeof(ValidatorFactory));
            AllowedFactories.Add(typeof(CacheFactory));
            AllowedFactories.Add(typeof(TranslatorFactory));
            AllowedFactories.Add(typeof(LoggerFactory));
            AllowedFactories.Add(typeof(StorerFactory));
        }

        public static ModuleConfiguration Exec(PluginConfiguration configHelper)
        {
            var moduleConfiguration = new ModuleConfiguration();

            foreach (var allowedFactory in AllowedFactories)
            {
                var factory = (IConfigurableFactory) Activator.CreateInstance(allowedFactory);
                factory.Configure(configHelper);
                moduleConfiguration.Factories.Add(allowedFactory,factory);
            }

            return moduleConfiguration;
        }
    }
}