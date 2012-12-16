using System.Reflection;

namespace EasyArchitecture.Runtime
{
    public class ModuleAssemblies
    {
        internal readonly Assembly DomainAssembly;
        internal readonly Assembly ApplicationAssembly;
        internal readonly Assembly InfrastructureAssembly;
        public string ModuleName;

        public ModuleAssemblies(Assembly applicationAssembly, Assembly domainAssembly, Assembly infrastructureAssembly)
        {
            ApplicationAssembly = applicationAssembly;
            DomainAssembly = domainAssembly;
            InfrastructureAssembly = infrastructureAssembly;
        }
    }
}