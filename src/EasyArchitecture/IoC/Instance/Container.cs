using System;
using System.Reflection;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Instance
{
    internal class Container
    {
        private readonly IContainer _plugin;

        internal Container(IContainer plugin)
        {
            _plugin = plugin;

            //AutoRegister(easyConfig.DomainAssembly, easyConfig.InfrastructureAssembly, false);
            //AutoRegister(easyConfig.ApplicationAssembly, easyConfig.ApplicationAssembly, true);
        }

        //private void AutoRegister(Assembly interfacesAssembly, Assembly implementationsAssembly, bool useInterception)
        //{
        //    var implementationTypes = implementationsAssembly.GetExportedTypes();
        //    var interfaceTypes = interfacesAssembly.GetExportedTypes();

        //    foreach (var exportedType in interfaceTypes)
        //    {
        //        if (!exportedType.IsInterface) continue;

        //        var type = exportedType;
        //        var implementationType = Array.Find(implementationTypes,
        //                                            t => type.IsAssignableFrom(t) && !type.Equals(t));

        //        if (implementationType == null)
        //        {
        //            continue;
        //        }

        //        _plugin.Register(exportedType, implementationType, useInterception);
        //    }
        //}

        internal void Register<T, T1>() where T1 : T
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            _plugin.Register<T, T1>();
        }

        internal T Resolve<T>()
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            return _plugin.Resolve<T>();
        }
    }
}
