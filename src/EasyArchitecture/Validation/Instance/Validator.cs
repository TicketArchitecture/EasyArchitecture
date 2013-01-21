using System.Collections.Generic;
using EasyArchitecture.Runtime.Log;
using EasyArchitecture.Validation.Plugin.Contracts;

namespace EasyArchitecture.Validation.Instance
{
    internal class Validator
    {
        private readonly IValidator _plugin;

        internal Validator(IValidator plugin)
        {
            _plugin = plugin;
        }

        internal List<string> GetMessages<T>(T entity)
        {
            var ret=_plugin.Validate(entity);

            InstanceLogger.Log(this, "Translate", entity, ret);

            return ret;
        }

        internal void IsValid<T>(T entity)
        {
            var messages = _plugin.Validate(entity);

            InstanceLogger.Log(this, "IsValid", entity, messages);

            if (messages.Count != 0)
                throw new InvalidEntityException(messages.ToArray());
        }
    }
}
