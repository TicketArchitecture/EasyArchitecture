using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    internal class ValidatorPlugin : AbstractPlugin, IValidatorPlugin
    {
        private readonly Dictionary<Type, object> _validationRuleDefinitions = new Dictionary<Type, object>();

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            var assembly = moduleAssemblies.InfrastructureAssembly;
            foreach (var validator in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType != null && tipo.BaseType.IsGenericType && tipo.BaseType.GetGenericTypeDefinition() == typeof(ValidationRuleSet<>)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddValidator(validator);
                pluginInspector.Log("Adding validator for {0}", validator.GetType().Name);
            }
        }

        public IValidator GetInstance()
        {
            return new Validator(_validationRuleDefinitions);
        }


        private void AddValidator(object validatorRule)
        {
            var t = validatorRule.GetType().BaseType.GetGenericArguments()[0];

            if (!_validationRuleDefinitions.ContainsKey(t))
                _validationRuleDefinitions.Add(t, validatorRule);
        }
    }
}