using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Instances.Caching;
using EasyArchitecture.Instances.Configuration;
using EasyArchitecture.Instances.IoC;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Instances.Persistence;
using EasyArchitecture.Instances.Storage;
using EasyArchitecture.Instances.Translation;
using EasyArchitecture.Instances.Validation.Instance;
using EasyArchitecture.Mechanisms.Configuration.Exceptions;
using EasyArchitecture.Plugin.Contracts.Caching;
using EasyArchitecture.Plugin.Contracts.IoC;
using EasyArchitecture.Plugin.Contracts.Log;
using EasyArchitecture.Plugin.Contracts.Persistence;
using EasyArchitecture.Plugin.Contracts.Storage;
using EasyArchitecture.Plugin.Contracts.Translation;
using EasyArchitecture.Plugin.Contracts.Validation;

namespace EasyArchitecture.Core
{
    public static class InstanceProvider
    {
        private static readonly Dictionary<string, List<AbstractPlugin>> Factories = new Dictionary<string, List<AbstractPlugin>>();
        private static readonly Dictionary<Type, Type> Map = new Dictionary<Type, Type>();

        static InstanceProvider()
        {
            Map.Add(typeof(Persistence), typeof(IInstanceProvider<IPersistence>));
            Map.Add(typeof(Container), typeof(IInstanceProvider<IContainer>));
            Map.Add(typeof(Translator), typeof(IInstanceProvider<ITranslator>));
            Map.Add(typeof(Validator), typeof(IInstanceProvider<IValidator>));
            Map.Add(typeof(Storer), typeof(IInstanceProvider<IStorage>));
            Map.Add(typeof(Cache), typeof(IInstanceProvider<ICache>));
            Map.Add(typeof(Logger), typeof(IInstanceProvider<ILogger>));

        }

        public static T GetInstance<T>() where T : class
        {
            var instance = LocalThreadStorage.GetCurrentContext().GetInstance<T>();

            if (instance == null)
            {
                var moduleName = LocalThreadStorage.GetCurrentContext().Name;
                if (!Factories.ContainsKey(moduleName))
                    throw new NotConfiguredModuleException(moduleName);

                var list = Factories[moduleName];
                var pluginType = typeof(T);
                var providerType = Map[pluginType];
                var plugin = list.Find(providerType.IsInstanceOfType);
                var ret = providerType.InvokeMember("GetInstance", BindingFlags.InvokeMethod, null, plugin, null);
                instance= (T)Activator.CreateInstance(pluginType, ret);

                LocalThreadStorage.GetCurrentContext().SetInstance<T>(instance);
            }
            
            return (T)instance;
        }

        public static T GetLocalInstance<T>() where T : class
        {
            return LocalThreadStorage.GetCurrentContext() ==null?null: LocalThreadStorage.GetCurrentContext().GetInstance<T>();
        }

        internal static void Configure(string moduleName, PluginConfiguration pluginConfiguration)
        {
            var moduleAssemblies = AssemblyManager.GetModuleAssemblies(moduleName);
            var inspectors = new List<PluginInspector>();

            var list = pluginConfiguration.GetPluginList();
            foreach (var plugin in list)
            {
                PluginInspector pluginInspector;
                plugin.Configure(moduleAssemblies, out pluginInspector);
                inspectors.Add(pluginInspector);
            }
            Factories[moduleAssemblies.ModuleName] = list;

            var pluginInfo = new PluginInspectorExtrator(inspectors);

            //log after configuration because we must ensure that logger has been initialized
            LocalThreadStorage.CreateContext(moduleName);
            GetInstance<Logger>().Log(LogLevel.Debug, pluginInfo, null);
        }
    }

}