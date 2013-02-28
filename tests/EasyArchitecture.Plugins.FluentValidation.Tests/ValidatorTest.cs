using System;
using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugins.Validation.Validation;

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

            validatorPlugin.Configure(new ModuleAssemblies(moduleName, null, null, infraAssembly), out pluginInspector);
            Validator = validatorPlugin.GetInstance();
        }
    }
}
