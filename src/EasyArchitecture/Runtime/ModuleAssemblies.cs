using System.Reflection;

namespace EasyArchitecture.Configuration.Instance
{
    internal class ModuleAssemblies
    {
        internal readonly Assembly DomainAssembly;
        internal readonly Assembly ApplicationAssembly;
        internal readonly Assembly InfrastructureAssembly;

        public ModuleAssemblies(Assembly applicationAssembly, Assembly domainAssembly, Assembly infrastructureAssembly)
        {
            ApplicationAssembly = applicationAssembly;
            DomainAssembly = domainAssembly;
            InfrastructureAssembly = infrastructureAssembly;
        }
    }
}