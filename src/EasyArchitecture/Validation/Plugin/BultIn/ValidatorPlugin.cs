using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    internal class ValidatorPlugin : IValidatorPlugin
    {
        private readonly Dictionary<Type, object> List = new Dictionary<Type, object>();

        public void Configure(Assembly assembly)
        {
            foreach (var validator in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType != null && tipo.BaseType.IsGenericType && tipo.BaseType.GetGenericTypeDefinition() == typeof(Validator<>)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddValidator(validator);
            }
        }

        public IValidatorInstance GetInstance()
        {
            return new ValidatorInstance();
        }


        private void AddValidator(object validatorRule)
        {
            var t = validatorRule.GetType().BaseType.GetGenericArguments()[0];

            if (!List.ContainsKey(t))
                List.Add(t, validatorRule);
        }
    }
}