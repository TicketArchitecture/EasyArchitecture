using System;
using System.Collections.Generic;

namespace EasyArchitecture.Configuration.Instance
{
    public class PluginConfiguration
    {
        private readonly string _moduleName;
        private readonly Dictionary<Type, object> _plugins = new Dictionary<Type, object>();
        public string ModuleName;

        public PluginConfiguration(string moduleName)
        {
            _moduleName = moduleName;
            ModuleName = moduleName;
        }

        internal void Register<T>(T plugin)
        {
            _plugins.Add(typeof(T), plugin);
        }

        internal void Register<TU, T>()
        {
            var type = typeof(T);
            var plugin = type.Assembly.CreateInstance(type.FullName);
            Register((TU)plugin);
        }

        public Dictionary<Type, object> GetConfiguredPlugins()
        {
            return _plugins;
        }

        public T GetPlugin<T>()
        {
            return (T) _plugins[typeof(T)];
        }

        public void Register(Type pluginType, object o)
        {
            _plugins.Add(pluginType, o);
        }
    }
}