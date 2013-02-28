using System;
using System.Collections.Generic;
using EasyArchitecture.Core.Contracts;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Caching;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Instances.IoC;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Instances.Persistence;
using EasyArchitecture.Instances.Storage;
using EasyArchitecture.Instances.Translation;
using EasyArchitecture.Instances.Validation.Instance;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Core
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
            AllowedFactories.Add(typeof(Persistence), typeof(PersistenceFactory));
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