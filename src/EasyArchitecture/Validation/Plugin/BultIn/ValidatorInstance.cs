using System;
using System.Collections.Generic;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    internal class ValidatorInstance : IValidatorInstance
    {
        private readonly Dictionary<Type,object> List = new Dictionary<Type, object>();

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
    }
}