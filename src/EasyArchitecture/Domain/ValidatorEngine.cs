using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Diagnostic;

namespace EasyArchitecture.Domain
{
    public static class ValidatorEngine
    {
        private static readonly Dictionary<Type,object> List = new Dictionary<Type, object>();

        private static List<string> Validate<T>(T entity)
        {
            var list = new List<string>();

            if (List.ContainsKey(typeof(T)))
            {
                var validator = (Validator<T>)List[typeof(T)];
                list.AddRange(validator.Validate(entity));
            }

            return list;
        }

        private static void AddValidator<T>(Validator<T> validatorRule)
        {
            List.Add(typeof(T), validatorRule);
        }

        private static void AddValidator(object validatorRule)
        {
            var t = validatorRule.GetType().BaseType.GetGenericArguments()[0];

            Log.To(typeof(ValidatorEngine)).Message("Adding validationRule [{0}] for [{1}] type", validatorRule,t).Debug();

            if (!List.ContainsKey(t))
                List.Add(t, validatorRule);
        }

        public static List<string> GetMessages<T>(T entity)
        {
            return Validate(entity);
        }

        public static void IsValid<T>(T entity)
        {
            var messages = Validate(entity);
            if (messages.Count != 0)
                throw new InvalidEntityException(messages.ToArray());
        }

        internal static void Configure(Assembly assembly)
        {
            foreach (var validator in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType != null && tipo.BaseType.IsGenericType && tipo.BaseType.GetGenericTypeDefinition() == typeof(Validator<>)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddValidator(validator);
            }
        }
    }
}
