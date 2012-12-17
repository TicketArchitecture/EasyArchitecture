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
using EasyArchitecture.Validation.Plugin.BultIn;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Runtime
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

            //complete configuration
            foreach (var builtinPlugin in BuiltinPlugins)
            {
                if(!configuredPlugins.ContainsKey(builtinPlugin.Key))
                {
                    var plugin = Activator.CreateInstance(builtinPlugin.Value);
                    pluginConfiguration.Register(builtinPlugin.Key,plugin);
                }
            }

            
        }
    }
}