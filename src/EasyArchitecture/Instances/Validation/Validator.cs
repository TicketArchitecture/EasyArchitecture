﻿using System.Collections.Generic;
using EasyArchitecture.Core.Log;
using EasyArchitecture.Plugin.Contracts.Validation;

namespace EasyArchitecture.Instances.Validation.Instance
{
    internal class Validator
    {
        private readonly IValidator _plugin;

        //TODO: must be internal but i did to activator use
        public Validator(IValidator plugin)
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