using System;
using System.Reflection;

namespace EasyArchitecture.Plugins.Contracts.IoC
{
    public abstract class AbstractContainerPlugin : Plugin
    {

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            ConfigureContainerPlugin(pluginInspector);

            AutoRegister(pluginConfiguration.DomainAssembly, pluginConfiguration.InfrastructureAssembly, false, pluginInspector);
            AutoRegister(pluginConfiguration.ApplicationAssembly, pluginConfiguration.ApplicationAssembly, true, pluginInspector);
        }

        protected abstract void ConfigureContainerPlugin(PluginInspector pluginInspector);
        
       

        private void AutoRegister(Assembly interfacesAssembly, Assembly implementationsAssembly, bool useInterception, PluginInspector pluginInspector)
        {
            var implementationTypes = implementationsAssembly.GetExportedTypes();
            var interfaceTypes = interfacesAssembly.GetExportedTypes();

            foreach (var exportedType in interfaceTypes)
            {
                if (!exportedType.IsInterface) 
                    continue;

                var type = exportedType;
                var implementationType = Array.Find(implementationTypes,
                                                    t => type.IsAssignableFrom(t) && !type.Equals(t));
                if (implementationType == null)
                    continue;

                pluginInspector.Log("Interface {0} are mapped to {1}, {2} using interception", exportedType.FullName, implementationType.FullName,
                                    useInterception ? string.Empty : "NOT");

                if (useInterception)
                    Register(exportedType, implementationType, pluginInspector);
                else
                    RegisterWithInterception(exportedType, implementationType, pluginInspector);
            }
        }

        protected abstract void Register(Type interfaceType, Type concreteType, PluginInspector pluginInspector);

        protected abstract void RegisterWithInterception(Type interfaceType, Type concreteType, PluginInspector pluginInspector);
    }
}