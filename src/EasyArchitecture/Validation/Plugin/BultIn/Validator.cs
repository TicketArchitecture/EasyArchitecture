using System;
using System.Collections.Generic;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    internal class Validator : IValidator
    {
        private readonly Dictionary<Type, object> _validationRuleSets;

        public Validator(Dictionary<Type, object> validationRuleDefinitions)
        {
            _validationRuleSets = validationRuleDefinitions;
        }

        public List<string> Validate<T>(T entity)
        {
            var list = new List<string>();

            if (_validationRuleSets.ContainsKey(typeof(T)))
            {
                var ruleSet = (ValidationRuleSet<T>)_validationRuleSets[typeof(T)];
                list.AddRange(ruleSet.Apply(entity));
            }

            return list;
        }
    }
}