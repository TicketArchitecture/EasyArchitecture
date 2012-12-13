using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    public abstract class Validator<T>
    {
        private readonly List<ValidationRule<T>> _validationRules = new List<ValidationRule<T>>();

        public IEnumerable<string> Validate(T entity)
        {
            return (from validationRule in _validationRules
                    where validationRule.Rule.Invoke(entity)
                    select validationRule.Message).ToList();
        }

        protected void AddRule(Func<T, bool> rule, string message)
        {
            _validationRules.Add(new ValidationRule<T>() { Rule = rule, Message = message });
        }
    }
}