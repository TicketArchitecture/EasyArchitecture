using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Plugins;
using EasyArchitecture.Plugins.BultIn.Caching;
using EasyArchitecture.Plugins.BultIn.IoC;
using EasyArchitecture.Plugins.BultIn.Log;
using EasyArchitecture.Plugins.BultIn.Persistence;
using EasyArchitecture.Plugins.BultIn.Storage;
using EasyArchitecture.Plugins.BultIn.Translation;
using EasyArchitecture.Plugins.BultIn.Validation;
using EasyArchitecture.Plugins.Contracts.Caching;
using EasyArchitecture.Plugins.Contracts.IoC;
using EasyArchitecture.Plugins.Contracts.Log;
using EasyArchitecture.Plugins.Contracts.Persistence;
using EasyArchitecture.Plugins.Contracts.Storage;
using EasyArchitecture.Plugins.Contracts.Translation;
using EasyArchitecture.Plugins.Contracts.Validation;

namespace EasyArchitecture.Configuration
{
    internal class PluginSetup
    {
        private readonly Dictionary<Type, Plugin> _plugins;

        private PluginSetup(Dictionary<Type, Plugin> plugins)
        {
            _plugins = plugins;
        }

        internal static PluginSetup Create()
        {
            var plugins = new Dictionary<Type, Plugin>
                {
                    {typeof (IValidatorPlugin), new ValidatorPlugin()},
                    {typeof (ILoggerPlugin), new LoggerPlugin()},
                    {typeof (ITranslatorPlugin), new TranslatorPlugin()},
                    {typeof (ICachePlugin), new CachePlugin()},
                    {typeof (IStoragePlugin), new StoragePlugin()},
                    {typeof (IPersistencePlugin), new PersistencePlugin()},
                    {typeof (IContainerPlugin), new ContainerPlugin()}
                };

            return new PluginSetup(plugins);
        }

        internal void Register<T>(T plugin)
        {
            var abstractPlugin = plugin as Plugin;
            _plugins[typeof(T)] = abstractPlugin;
        }

        internal void Register<TU, T>()
        {
            var type = typeof(T);
            var plugin = type.Assembly.CreateInstance(type.FullName);
            Register((TU)plugin);
        }

        internal List<Plugin> GetPlugins()
        {
            return _plugins.Select(plugin => plugin.Value).ToList();
        }
    }

}