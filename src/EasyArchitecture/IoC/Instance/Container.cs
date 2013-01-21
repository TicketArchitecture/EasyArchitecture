using System;
using System.Reflection;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Runtime.Log;

namespace EasyArchitecture.IoC.Instance
{
    internal class Container
    {
        private readonly IContainer _plugin;

        internal Container(IContainer plugin)
        {
            _plugin = plugin;

            //TODO: clean
            //AutoRegister(easyConfig.DomainAssembly, easyConfig.InfrastructureAssembly, false);
            //AutoRegister(easyConfig.ApplicationAssembly, easyConfig.ApplicationAssembly, true);
        }

        //TODO: clean
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

            InstanceLogger.Log(this, "Register", typeof(T).Name, typeof(T1).Name);
        }

        internal T Resolve<T>()
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            var ret= _plugin.Resolve<T>();

            InstanceLogger.Log(this, "Resolve", typeof(T).Name, ret.GetType().Name);

            return ret;
        }
    }
}
