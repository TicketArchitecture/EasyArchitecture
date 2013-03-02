using System;
using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Tests.Validation;

namespace EasyArchitecture.Plugins.FluentValidation.Tests
{
    public class ValidatorTest : MinimalValidatorTest
    {
        public override void SetUp()
        {
            var moduleName = Guid.NewGuid().ToString();

            var validatorPlugin = new FluentValidationPlugin();
            PluginInspector pluginInspector;

            var infraAssembly = Assembly.GetExecutingAssembly();

            validatorPlugin.Configure(new PluginConfiguration(moduleName, null, null, infraAssembly), out pluginInspector);
            Validator = validatorPlugin.GetInstance();
        }
    }
}
