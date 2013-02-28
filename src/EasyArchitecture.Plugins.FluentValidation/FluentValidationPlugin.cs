using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.Contracts.Validation;
using FluentValidation;

namespace EasyArchitecture.Plugins.FluentValidation
{
    public class FluentValidationPlugin : AbstractPlugin, IValidatorPlugin
    {
        private readonly Dictionary<Type, object> _validationRuleDefinitions = new Dictionary<Type, object>();

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            var assembly = moduleAssemblies.InfrastructureAssembly;
            foreach (var validator in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType != null && tipo.BaseType.IsGenericType && tipo.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddValidator(validator);
                pluginInspector.Log("Adding validator for {0}", validator.GetType().Name);
            }

        }

        public EasyArchitecture.Plugin.Contracts.Validation.IValidator GetInstance()
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
