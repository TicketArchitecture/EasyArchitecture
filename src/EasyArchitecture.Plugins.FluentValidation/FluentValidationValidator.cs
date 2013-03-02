using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using IValidator = EasyArchitecture.Plugins.Contracts.Validation.IValidator;

namespace EasyArchitecture.Plugins.FluentValidation
{
    public class FluentValidationValidator : IValidator
    {
        private readonly Dictionary<Type, object> _validationRuleSets;

        public FluentValidationValidator(Dictionary<Type, object> validationRuleDefinitions)
        {
            _validationRuleSets = validationRuleDefinitions;    
        }

        public List<string> Validate<T>(T obj)
        {
            var list = new List<string>();

            if (_validationRuleSets.ContainsKey(typeof(T)))
            {
                var validator = (AbstractValidator<T>)_validationRuleSets[typeof(T)];
                var results = validator.Validate(obj);
                list.AddRange(results.Errors.Select(error => error.ErrorMessage));
            }

            return list;
        }
    }
}
