using System;
using System.Reflection;
using System.Text;

namespace EasyArchitecture.Internal
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
            return AppDomain.CurrentDomain.Load(assemblyName);
        }

        internal static string RemoveAssemblySufix(string name)
        {
            var sb = new StringBuilder(name);

            sb.Replace(Contract, String.Empty);
            sb.Replace(Application, String.Empty);
            sb.Replace(Domain, String.Empty);
            sb.Replace(Infrastructure, String.Empty);

            return sb.ToString();
        }

        internal static string ModuleName<T>()
        {
            var type = typeof(T);
            var assemblyName = type.Assembly.GetName().Name;
            var moduleName = RemoveAssemblySufix(assemblyName);
            return moduleName;
        }
    }
}
