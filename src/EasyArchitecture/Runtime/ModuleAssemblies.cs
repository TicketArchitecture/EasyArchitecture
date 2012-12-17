using System.Reflection;

namespace EasyArchitecture.Runtime
{
    public class ModuleAssemblies
    {
        internal readonly Assembly DomainAssembly;
        //private readonly string _moduleName;
        internal readonly Assembly ApplicationAssembly;
        internal readonly Assembly InfrastructureAssembly;
        public string ModuleName;

        public ModuleAssemblies(string moduleName, Assembly applicationAssembly, Assembly domainAssembly, Assembly infrastructureAssembly)
        {
            ModuleName = moduleName;
            ApplicationAssembly = applicationAssembly;
            DomainAssembly = domainAssembly;
            InfrastructureAssembly = infrastructureAssembly;
        }
    }
}