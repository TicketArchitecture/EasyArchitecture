using System;
using System.Collections.Generic;
using EasyArchitecture.Caching.Instance;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.Log.Instance;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Persistence.Instance;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Runtime.Plugin;
using EasyArchitecture.Storage.Instance;
using EasyArchitecture.Translation.Instance;
using EasyArchitecture.Validation.Instance;
using Cache = EasyArchitecture.Caching.Instance.Cache;

namespace EasyArchitecture.Runtime
{
    public static class FactoryInitializer
    {
        private static readonly Dictionary<Type, Type> AllowedFactories = new Dictionary<Type, Type>();

        static FactoryInitializer()
        {
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
            var moduleAssemblies = AssemblyManager.GetModuleAssemblies(pluginConfiguration.ModuleName);

            foreach (var allowedFactory in AllowedFactories)
            {
                var factory = (IConfigurableFactory)Activator.CreateInstance(allowedFactory.Value, moduleAssemblies);
                moduleConfiguration.Factories.Add(allowedFactory.Key, factory);

                PluginInspector pluginInspector;
                factory.Configure(pluginConfiguration, out pluginInspector);
                moduleConfiguration.AddPluginConfigurationInfo(pluginInspector);
            }

            //log after configuration because we must ensure that logger has been initialized
            var loggerFactory= (LoggerFactory)moduleConfiguration.Factories[typeof(Logger)];
            loggerFactory.GetInstance().Log(LogLevel.Debug, moduleConfiguration.GetPluginConfigurationInfo(), null);

            return moduleConfiguration;
        }
    }
}