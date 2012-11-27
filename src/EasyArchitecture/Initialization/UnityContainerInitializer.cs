using System;
using System.Reflection;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Initialization
{
    internal static class UnityContainerInitializer
    {
        private static IUnityContainer Container { get; set; }

        internal static void Configure()
        {
            if (Container != null) return;

            Container = new UnityContainer();
            Container.AddNewExtension<Interception>();

            InitializeServiceLocator();

            ConfigurePoliceInterceptor();

            Log.To(typeof(UnityContainerInitializer)).Message("Container initialized").Debug();
        }

        internal static void AutoRegister(Assembly interfaceAssembly, Assembly implementationAssembly, bool useInterception)
        {
            ContainerConfig(interfaceAssembly, implementationAssembly, useInterception);
        }

        private static void InitializeServiceLocator()
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(Container));

            Log.To(typeof(UnityContainerInitializer)).Message("Service Locator Configured").Debug();
        }

        private static void ContainerConfig(Assembly interfacesAssembly, Assembly implementationAssembly, bool useInterception)
        {
            var implementationTypes = implementationAssembly.GetExportedTypes();
            var interfaceTypes = interfacesAssembly.GetExportedTypes();

            Log.To(typeof(UnityContainerInitializer)).Message("Mapping interfaces from [{0}] to [{1}]", interfacesAssembly.FullName, implementationAssembly.FullName).Debug();

            foreach (var exportedType in interfaceTypes)
            {
                if (!exportedType.IsInterface) continue;

                var type = exportedType;
                var implementationType = Array.Find(implementationTypes, t => type.IsAssignableFrom(t) && !type.Equals(t));

                if (implementationType == null)
                {
                    Log.To(typeof(UnityContainerInitializer)).Message("Not found implementation for [{0}]", exportedType.Name).Debug();
                    continue;
                }

                if (useInterception)
                {
                    Container.RegisterType(
                        exportedType, implementationType,
                        new InterceptionBehavior<PolicyInjectionBehavior>(),
                        new Interceptor<VirtualMethodInterceptor>());


                }
                else
                {
                    Container.RegisterType(exportedType, implementationType, null, null);
                }

                Log.To(typeof(UnityContainerInitializer)).Message("Mapped [{0}] to [{1}] with interception [{2}]", exportedType.Name, implementationType.Name, useInterception).Debug();
            }
        }

        public static void Register<T, U>() where U : T
        {
            var type = typeof(T);
            if (!type.IsInterface)
                throw new Exception("T must be an interface");

            if (AssemblyManager.IsContractAssembly(type.Assembly))
            {
                Container.RegisterType(
                    typeof(T), typeof(U),
                    new InterceptionBehavior<PolicyInjectionBehavior>(),
                    new Interceptor<VirtualMethodInterceptor>());
                return;
            }

            if (AssemblyManager.IsDomainAssembly(type.Assembly))
            {
                Container.RegisterType<T, U>();
                return;
            }

            throw new Exception("T must a facade interface, a domain service interface or a domain repository interface");

        }

        public static void OutterRegister<T, U>() where U : T
        {
            Container.RegisterType<T, U>();
        }

        private static void ConfigurePoliceInterceptor()
        {
            Container.Configure<Interception>()
                .AddPolicy("Context")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(true)))
                .AddCallHandler(typeof(ContextHandler));
            Container.Configure<Interception>()
                .AddPolicy("Loggining")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(true)))
                .AddCallHandler(typeof(LoggingHandler));
            Container.Configure<Interception>()
                .AddPolicy("Transaction")
                .AddMatchingRule<FacadeMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(false)))
                .AddCallHandler(typeof(TransactionHandler));
        }
    }
}
