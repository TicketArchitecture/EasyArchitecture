using System.Reflection;

namespace EasyArchitecture.Core
{
    public class ModuleAssemblies
    {
        public readonly Assembly DomainAssembly;
        public readonly Assembly ApplicationAssembly;
        public readonly Assembly InfrastructureAssembly;
        public readonly string ModuleName;

        public ModuleAssemblies(string moduleName, Assembly applicationAssembly, Assembly domainAssembly, Assembly infrastructureAssembly)
        {
            ModuleName = moduleName;
            ApplicationAssembly = applicationAssembly;
            DomainAssembly = domainAssembly;
            InfrastructureAssembly = infrastructureAssembly;
        }
    }
}