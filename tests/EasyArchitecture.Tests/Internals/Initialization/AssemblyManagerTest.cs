using EasyArchitecture.Runtime;
using EasyArchitecture.Tests.Stuff.Helpers;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Internals.Initialization
{
    [TestFixture]
    public class AssemblyManagerTest
    {
        private const string ModuleName = "Application4Test";

        [Test]
        public void Can_get_domain_assemblies()
        {
            var expected = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.DomainAssemblyName);
            var actual = AssemblyManager.GetModuleAssemblies(ModuleName).DomainAssembly;

            Assert.That(actual,Is.EqualTo(expected));
        }

        [Test]
        public void Can_get_infrastructure_assemblies()
        {
            var expected = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.InfrastructureAssemblyName);
            var actual = AssemblyManager.GetModuleAssemblies(ModuleName).InfrastructureAssembly;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_get_application_assemblies()
        {
            var expected = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.ApplicationAssemblyName);
            var actual = AssemblyManager.GetModuleAssemblies(ModuleName).ApplicationAssembly;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Can_remove_sufix_from_assembly_name()
        {
            var expected = AssemblyLoader.ApplicationAssemblyName.Replace(".Application",string.Empty);
            var actual = AssemblyManager.RemoveAssemblySufix(AssemblyLoader.ApplicationAssemblyName);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
