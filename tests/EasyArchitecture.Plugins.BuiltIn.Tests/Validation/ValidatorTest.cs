using System;
using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.BultIn.Validation;
using EasyArchitecture.Plugins.Validation.Validation;
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

            validatorPlugin.Configure(new ModuleAssemblies(moduleName, null, null, infraAssembly), out pluginInspector);
            Validator = validatorPlugin.GetInstance();
        }
    }
}
