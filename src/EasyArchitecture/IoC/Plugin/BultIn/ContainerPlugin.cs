using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class ContainerPlugin : IContainerPlugin
    {

        private readonly Dictionary<Type, TypeRegistry> _registeredTypes = new Dictionary<Type, TypeRegistry>();

        public void Configure(ModuleAssemblies moduleAssemblies)
        {
            AutoRegister(moduleAssemblies.DomainAssembly, moduleAssemblies.InfrastructureAssembly, false);
            AutoRegister(moduleAssemblies.ApplicationAssembly, moduleAssemblies.ApplicationAssembly, true);
        }

        private void AutoRegister(Assembly interfacesAssembly, Assembly implementationsAssembly, bool useInterception)
        {
            var implementationTypes = implementationsAssembly.GetExportedTypes();
            var interfaceTypes = interfacesAssembly.GetExportedTypes();

            foreach (var exportedType in interfaceTypes)
            {
                if (!exportedType.IsInterface) continue;

                var type = exportedType;
                var implementationType = Array.Find(implementationTypes,
                                                    t => type.IsAssignableFrom(t) && !type.Equals(t));

                if (implementationType == null)
                {
                    continue;
                }

                _registeredTypes.Add(exportedType, new TypeRegistry(implementationType,useInterception));
                //_plugin.Register(exportedType, implementationType, useInterception);
            }
        }
        public IContainer GetInstance()
        {
            return new Container(_registeredTypes);
        }
    }

}