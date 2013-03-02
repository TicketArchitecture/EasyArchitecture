using System;
using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.BultIn.Validation;
using EasyArchitecture.Plugins.Tests.Validation;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Validation
{
    [TestFixture]
    public class ValidatorTest : MinimalValidatorTest
    {
        [SetUp]
        public override void SetUp()
        {
            var moduleName = Guid.NewGuid().ToString();

            var validatorPlugin = new ValidatorPlugin();
            PluginInspector pluginInspector;

            var infraAssembly = Assembly.GetExecutingAssembly();

            validatorPlugin.Configure(new PluginConfiguration(moduleName, null, null, infraAssembly), out pluginInspector);
            Validator = validatorPlugin.GetInstance();
        }
    }
}
