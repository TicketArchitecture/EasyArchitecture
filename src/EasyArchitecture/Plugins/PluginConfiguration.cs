using System.Reflection;

namespace EasyArchitecture.Plugins
{
    public class PluginConfiguration
    {
        public readonly Assembly DomainAssembly;
        public readonly Assembly ApplicationAssembly;
        public readonly Assembly InfrastructureAssembly;
        public readonly string ModuleName;

        public PluginConfiguration(string moduleName, Assembly applicationAssembly, Assembly domainAssembly, Assembly infrastructureAssembly)
        {
            ModuleName = moduleName;
            ApplicationAssembly = applicationAssembly;
            DomainAssembly = domainAssembly;
            InfrastructureAssembly = infrastructureAssembly;
        }
    }
}