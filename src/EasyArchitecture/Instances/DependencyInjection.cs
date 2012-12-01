using System;
using System.Reflection;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class DependencyInjection 
    {
        private readonly EasyConfig _easyConfig;

        internal DependencyInjection(EasyConfig easyConfig)
        {
            _easyConfig = easyConfig;

            this.AutoRegister(easyConfig.DomainAssembly, easyConfig.InfrastructureAssembly, false);
            this.AutoRegister(easyConfig.ApplicationAssembly, easyConfig.ApplicationAssembly, true);
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

                //get plugin
                var plugin = (IDependencyInjectionPlugin) _easyConfig.Plugins[typeof (IDependencyInjectionPlugin)];

                //execute
                plugin.RegisterType(exportedType, implementationType, useInterception);

            }
        }

        public T Resolve<T>()
        {
            //get plugin
            var plugin = (IDependencyInjectionPlugin)_easyConfig.Plugins[typeof(IDependencyInjectionPlugin)];

            //execute
            return plugin.GetInstance<T>();
        }

        public void Register<T, T1>() where T1 : T
        {
            //get plugin
            var plugin = (IDependencyInjectionPlugin)_easyConfig.Plugins[typeof(IDependencyInjectionPlugin)];

            //execute
            plugin.Register<T, T1>();

        }
    }
}
