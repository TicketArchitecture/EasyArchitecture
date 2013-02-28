using System;
using System.Collections.Generic;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Plugin.BultIn.Caching;
using EasyArchitecture.Plugin.BultIn.IoC;
using EasyArchitecture.Plugin.BultIn.Log;
using EasyArchitecture.Plugin.BultIn.Persistence;
using EasyArchitecture.Plugin.BultIn.Storage;
using EasyArchitecture.Plugin.BultIn.Translation;
using EasyArchitecture.Plugin.BultIn.Validation;
using EasyArchitecture.Plugin.Contracts.Caching;
using EasyArchitecture.Plugin.Contracts.IoC;
using EasyArchitecture.Plugin.Contracts.Log;
using EasyArchitecture.Plugin.Contracts.Persistence;
using EasyArchitecture.Plugin.Contracts.Storage;
using EasyArchitecture.Plugin.Contracts.Translation;
using EasyArchitecture.Plugin.Contracts.Validation;

namespace EasyArchitecture.Core
{
    public static class PluginConfigurationNormalizer
    {
        private static readonly Dictionary<Type, Type> BuiltinPlugins = new Dictionary<Type, Type>();

        static PluginConfigurationNormalizer()
        {
            BuiltinPlugins.Add(typeof (IValidatorPlugin), typeof (ValidatorPlugin));
            BuiltinPlugins.Add(typeof (ILoggerPlugin), typeof (LoggerPlugin));
            BuiltinPlugins.Add(typeof (ITranslatorPlugin), typeof (TranslatorPlugin));
            BuiltinPlugins.Add(typeof (ICachePlugin), typeof (CachePlugin));
            BuiltinPlugins.Add(typeof (IStoragePlugin), typeof (StoragePlugin));
            BuiltinPlugins.Add(typeof (IPersistencePlugin), typeof (PersistencePlugin));
            BuiltinPlugins.Add(typeof(IContainerPlugin), typeof(ContainerPlugin));
        }

        public static void Normalize( PluginConfiguration pluginConfiguration)
        {
            var configuredPlugins =  pluginConfiguration.GetConfiguredPlugins();

            CompletePluginIntanceList(pluginConfiguration, configuredPlugins);
        }

        private static void CompletePluginIntanceList(PluginConfiguration pluginConfiguration, Dictionary<Type, object> configuredPlugins)
        {
            foreach (var builtinPlugin in BuiltinPlugins)
            {
                if (!configuredPlugins.ContainsKey(builtinPlugin.Key))
                {
                    var plugin = Activator.CreateInstance(builtinPlugin.Value);
                    pluginConfiguration.Register(builtinPlugin.Key, plugin);
                }
            }
        }
    }
}