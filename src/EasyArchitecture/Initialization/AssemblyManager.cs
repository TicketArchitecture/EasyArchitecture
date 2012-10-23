using System;
using System.Reflection;
using System.Text;
using EasyArchitecture.Diagnostic;

namespace EasyArchitecture.Initialization
{
    internal static class AssemblyManager
    {
        private const string Application = ".Application";
        private const string Contract = ".Application.Contracts";
        private const string Domain = ".Domain";
        private const string Infrastructure = ".Infrastructure";

        internal static Assembly GetDomainAssembly(string businessModuleName)
        {
            return GetAssembly(Domain, businessModuleName);
        }

        internal static Assembly GetInfrastructureAssembly(string businessModuleName)
        {
            return GetAssembly(Infrastructure, businessModuleName);
        }

        internal static Assembly GetApplicationAssembly(string businessModuleName)
        {
            return GetAssembly(Application, businessModuleName);
        }

        private static Assembly GetAssembly(string assemblyType, string businessModuleName)
        {
            var assemblyName = businessModuleName + assemblyType;

            var ret = AppDomain.CurrentDomain.Load(assemblyName);

            Log.To(typeof(AssemblyManager)).Message("Found [{0}] assembly.", ret).Debug();

            return ret;
        }


        internal static string RemoveAssemblySufix(string name)
        {
            var sb = new StringBuilder(name);

            sb.Replace(Contract, string.Empty);
            sb.Replace(Application, string.Empty);
            sb.Replace(Domain, string.Empty);
            sb.Replace(Infrastructure, string.Empty);
            
            var ret = sb.ToString();

            Log.To(typeof(AssemblyManager)).Message("Remove assembly sufix: [{0}] to [{1}] ", name, ret).Debug();

            return ret;
        }

        private static bool IsAssemblyKind(Assembly assembly, string assemblyKind)
        {
            var name = assembly.GetName().Name;
            var ret = name.EndsWith(assemblyKind);

            Log.To(typeof(AssemblyManager)).Message("Assembly is [{0}]? [{1}] ", assemblyKind, ret).Debug();

            return ret;
            
        }

        internal static bool IsContractAssembly(Assembly assembly)
        {
            return IsAssemblyKind(assembly,Application);
        }

        public static bool IsDomainAssembly(Assembly assembly)
        {
            return IsAssemblyKind(assembly, Domain);
        }
    }
}
