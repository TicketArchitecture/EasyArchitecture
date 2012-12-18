using System.Reflection;

namespace EasyArchitecture.Runtime
{
    public class ModuleAssemblies
    {
        public readonly Assembly DomainAssembly;
        //private readonly string _moduleName;
        public readonly Assembly ApplicationAssembly;
        public readonly Assembly InfrastructureAssembly;
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