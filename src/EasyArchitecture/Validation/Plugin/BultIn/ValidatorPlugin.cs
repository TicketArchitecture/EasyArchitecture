using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Runtime;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    internal class ValidatorPlugin : IValidatorPlugin
    {
        private readonly Dictionary<Type, object> _validationRuleDefinitions = new Dictionary<Type, object>();

        public void Configure(ModuleAssemblies moduleAssemblies)
        {
            var assembly = moduleAssemblies.InfrastructureAssembly;
            foreach (var validator in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType != null && tipo.BaseType.IsGenericType && tipo.BaseType.GetGenericTypeDefinition() == typeof(ValidationRuleSet<>)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddValidator(validator);
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