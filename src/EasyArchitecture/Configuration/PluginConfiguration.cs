using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Core.Plugin;
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

namespace EasyArchitecture.Configuration
{
    public class PluginConfiguration
    {
        private readonly Dictionary<Type, AbstractPlugin> _plugins;

        private PluginConfiguration(Dictionary<Type, AbstractPlugin> plugins)
        {
            _plugins = plugins;
        }

        internal static PluginConfiguration Create()
        {
            var plugins = new Dictionary<Type, AbstractPlugin>
                {
                    {typeof (IValidatorPlugin), new ValidatorPlugin()},
                    {typeof (ILoggerPlugin), new LoggerPlugin()},
                    {typeof (ITranslatorPlugin), new TranslatorPlugin()},
                    {typeof (ICachePlugin), new CachePlugin()},
                    {typeof (IStoragePlugin), new StoragePlugin()},
                    {typeof (IPersistencePlugin), new PersistencePlugin()},
                    {typeof (IContainerPlugin), new ContainerPlugin()}
                };

            return new PluginConfiguration(plugins);
        }

        internal void Register<T>(T plugin)
        {
            var abstractPlugin = plugin as AbstractPlugin;
            _plugins[typeof(T)] = abstractPlugin;
        }

        internal void Register<TU, T>()
        {
            var type = typeof(T);
            var plugin = type.Assembly.CreateInstance(type.FullName);
            Register((TU)plugin);
        }

        internal List<AbstractPlugin> GetPluginList()
        {
            return _plugins.Select(plugin => plugin.Value).ToList();
        }
    }

}