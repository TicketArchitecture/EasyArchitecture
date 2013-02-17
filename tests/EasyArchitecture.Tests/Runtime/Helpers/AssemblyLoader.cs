using System;
using System.Reflection;

namespace EasyArchitecture.Tests.Stuff.Helpers
{
    public static class AssemblyLoader
    {
        internal const string ApplicationAssemblyName = "Application4Test.Application";
        internal const string DomainAssemblyName = "Application4Test.Domain";
        internal const string InfrastructureAssemblyName = "Application4Test.Infrastructure";
        


        internal static Assembly LoadAssemblyFromFile(string assemblyName)
        {
            return Assembly.LoadFrom(
                System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    assemblyName + ".dll"
                    ));
            
        }
    }
}
