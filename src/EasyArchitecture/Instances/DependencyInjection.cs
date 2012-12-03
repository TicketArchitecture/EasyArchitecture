using System;
using System.Reflection;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class DependencyInjection 
    {
        private readonly EasyConfig _easyConfig;
        private readonly IDependencyInjectionPlugin _plugin;

        internal DependencyInjection(EasyConfig easyConfig)
        {
            _easyConfig = easyConfig;

            _plugin = (IDependencyInjectionPlugin)_easyConfig.Plugins[typeof(IDependencyInjectionPlugin)];

            AutoRegister(easyConfig.DomainAssembly, easyConfig.InfrastructureAssembly, false);
            AutoRegister(easyConfig.ApplicationAssembly, easyConfig.ApplicationAssembly, true);
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

                _plugin.Register(exportedType, implementationType, useInterception);
            }
        }

        internal T Resolve<T>()
        {
            return _plugin.Resolve<T>();
        }

        internal void Register<T, T1>() where T1 : T
        {
            _plugin.Register<T, T1>();
        }
    }
}
