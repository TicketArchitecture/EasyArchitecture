using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Plugins.Contracts.IoC;

namespace EasyArchitecture.Plugins.BultIn.IoC
{
    internal class ContainerPlugin : Plugin,IContainerPlugin
    {
        private readonly Dictionary<Type, TypeRegistry> _registeredTypes = new Dictionary<Type, TypeRegistry>();

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            AutoRegister(pluginConfiguration.DomainAssembly, pluginConfiguration.InfrastructureAssembly, false, pluginInspector);
            AutoRegister(pluginConfiguration.ApplicationAssembly, pluginConfiguration.ApplicationAssembly, true, pluginInspector);
        }

        private void AutoRegister(Assembly interfacesAssembly, Assembly implementationsAssembly, bool useInterception, PluginInspector pluginInspector)
        {
            var implementationTypes = implementationsAssembly.GetExportedTypes();
            var interfaceTypes = interfacesAssembly.GetExportedTypes();

            foreach (var interfaceType in interfaceTypes)
            {
                if (!interfaceType.IsInterface)
                    continue;

                var type = interfaceType;
                var concreteType = Array.Find(implementationTypes,
                                                    t => type.IsAssignableFrom(t) && !type.Equals(t));
                if (concreteType == null)
                    continue;

                pluginInspector.Log("Interface {0} are mapped to {1}, {2} using interception", interfaceType.FullName, concreteType.FullName,
                                    useInterception ? string.Empty : "NOT");
                
                _registeredTypes.Add(interfaceType, new TypeRegistry(concreteType, useInterception));
            }
        }

        public IContainer GetInstance()
        {
            return new Container(_registeredTypes);
        }
    }
}
