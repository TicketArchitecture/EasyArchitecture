using System;
using System.Reflection;
using System.Text;

namespace EasyArchitecture.Runtime
{
    internal static class AssemblyManager
    {
        private const string Application = ".Application";
        private const string Contract = ".Application.Contracts";
        private const string Domain = ".Domain";
        private const string Infrastructure = ".Infrastructure";

        private static Assembly GetAssembly(string assemblyType, string moduleName)
        {
            var assemblyName = moduleName + assemblyType;
            return AppDomain.CurrentDomain.Load(assemblyName);
        }

        internal static string RemoveAssemblySufix(string assemblyName)
        {
            var sb = new StringBuilder(assemblyName);

            sb.Replace(Contract, String.Empty);
            sb.Replace(Application, String.Empty);
            sb.Replace(Domain, String.Empty);
            sb.Replace(Infrastructure, String.Empty);

            return sb.ToString();
        }

        internal static string ModuleName<T>()
        {
            return ModuleName(typeof (T));
        }

        private static string ModuleName(Type type)
        {
            var assemblyName = type.Assembly.GetName().Name;
            var moduleName = RemoveAssemblySufix(assemblyName);
            return moduleName;
        }

        public static ModuleAssemblies GetModuleAssemblies(string moduleName)
        {
            return new ModuleAssemblies(
                moduleName,
                GetAssembly(Application, moduleName),
                GetAssembly(Domain, moduleName),
                GetAssembly(Infrastructure, moduleName)
                );
        }
    }
}
