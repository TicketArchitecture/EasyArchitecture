using System.Collections.Generic;
using EasyArchitecture.Configuration;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Configuration
{
    [TestFixture]
    public class ConfigurationManagerTest
    {
        [Test]
        public void GetBusinessModulesConfigurationTest()
        {
            var expected = new List<BusinessModuleConfig>()
            {new BusinessModuleConfig() {Name = "Application4Test", LogLevel = "debug",ConnectionString = string.Empty}};
            var actual = ConfigurationManager.GetBusinessModulesConfiguration();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetLogLevelTest()
        {
            const string expected = "debug";
            var actual = ConfigurationManager.GetLogLevel();

            Assert.That(actual,Is.EqualTo(expected));
        }

    }
}
