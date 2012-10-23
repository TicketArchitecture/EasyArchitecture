using System.Reflection;
using NUnit.Framework;
using EasyArchitecture.Initialization;

namespace EasyArchitecture.Tests.Initialization
{
    [TestFixture]
    public class AutoMapperInitializerTest
    {
        private const string BusinessModuleName = "Application4Test";
        private Assembly _assembly; 

        [Test]
        public void ConfigureTest()
        {
            _assembly = AssemblyManager.GetApplicationAssembly(BusinessModuleName);
            AutoMapperInitializer.Configure(_assembly);
        }

    }
}
