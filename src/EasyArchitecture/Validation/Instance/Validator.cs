using System.Collections.Generic;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Instance
{
    internal class Validator
    {
        private readonly IValidatorInstance _plugin;

        internal Validator(IValidatorInstance plugin)
        {
            _plugin = plugin;
        }

        internal List<string> GetMessages<T>(T entity)
        {
            return _plugin.Validate(entity);
        }

        internal void IsValid<T>(T entity)
        {
            var messages = _plugin.Validate(entity);
            if (messages.Count != 0)
                throw new InvalidEntityException(messages.ToArray());
        }
    }
}
