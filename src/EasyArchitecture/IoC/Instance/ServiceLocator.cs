using System;
using System.Reflection;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Instance
{
    internal class ServiceLocator 
    {
        private readonly ModuleConfiguration _easyConfig;
        private readonly IIoCPlugin _plugin;

        internal ServiceLocator(ModuleConfiguration easyConfig)
        {
            _easyConfig = easyConfig;

            _plugin = (IIoCPlugin)_easyConfig.Plugins[typeof(IIoCPlugin)];

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
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            return _plugin.Resolve<T>();
        }

        internal void Register<T, T1>() where T1 : T
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            _plugin.Register<T, T1>();
        }
    }
}
