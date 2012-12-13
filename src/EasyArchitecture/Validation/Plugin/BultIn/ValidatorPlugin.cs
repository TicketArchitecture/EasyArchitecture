using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    internal class ValidatorPlugin : IValidatorPlugin
    {
        private readonly Dictionary<Type,object> List = new Dictionary<Type, object>();

        public void Configure(Assembly assembly)
        {
                        foreach (var validator in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType != null && tipo.BaseType.IsGenericType && tipo.BaseType.GetGenericTypeDefinition() == typeof(Validator<>)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddValidator(validator);
            }
        }

        public List<string> Validate<T>(T entity)
        {
            var list = new List<string>();

            if (List.ContainsKey(typeof(T)))
            {
                var validator = (Validator<T>)List[typeof(T)];
                list.AddRange(validator.Validate(entity));
            }

            return list;
        }

        private void AddValidator<T>(Validator<T> validatorRule)
        {
            List.Add(typeof(T), validatorRule);
        }

        private void AddValidator(object validatorRule)
        {
            var t = validatorRule.GetType().BaseType.GetGenericArguments()[0];

            if (!List.ContainsKey(t))
                List.Add(t, validatorRule);
        }
    }
}