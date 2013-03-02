using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Validation;
using FluentValidation;
using IValidator = EasyArchitecture.Plugins.Contracts.Validation.IValidator;

namespace EasyArchitecture.Plugins.FluentValidation
{
    public class FluentValidationPlugin : Plugin, IValidatorPlugin
    {
        private readonly Dictionary<Type, object> _validationRuleDefinitions = new Dictionary<Type, object>();

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var assembly = pluginConfiguration.InfrastructureAssembly;
            foreach (var validator in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType != null && tipo.BaseType.IsGenericType && tipo.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddValidator(validator);
                pluginInspector.Log("Adding validator for {0}", validator.GetType().Name);
            }

        }

        public IValidator GetInstance()
        {
            return new FluentValidationValidator(_validationRuleDefinitions);
        }

        private void AddValidator(object validatorRule)
        {
            var t = validatorRule.GetType().BaseType.GetGenericArguments()[0];

            if (!_validationRuleDefinitions.ContainsKey(t))
                _validationRuleDefinitions.Add(t, validatorRule);
        }
    }
}
