﻿using EasyArchitecture.Tests.Stuff.Helpers;
using NUnit.Framework;
using EasyArchitecture.Initialization;

namespace EasyArchitecture.Tests.Internals.Initialization
{
    [TestFixture]
    public class AssemblyManagerTest
    {
        private const string BusinessModuleName = "Application4Test";

        [Test]
        public void GetDomainAssembliesTest()
        {
            var expected = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.DomainAssemblyName);
            var actual = AssemblyManager.GetDomainAssembly(BusinessModuleName);

            Assert.That(actual,Is.EqualTo(expected));
        }

        [Test]
        public void GetInfrastructureAssembliesTest()
        {
            var expected = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.InfrastructureAssemblyName);
            var actual = AssemblyManager.GetInfrastructureAssembly(BusinessModuleName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetApplicationAssembliesTest()
        {
            var expected = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.ApplicationAssemblyName);
            var actual = AssemblyManager.GetApplicationAssembly(BusinessModuleName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveAssemblySufixTest()
        {
            var expected = AssemblyLoader.ApplicationAssemblyName.Replace(".Application",string.Empty);
            var actual = AssemblyManager.RemoveAssemblySufix(AssemblyLoader.ApplicationAssemblyName);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}