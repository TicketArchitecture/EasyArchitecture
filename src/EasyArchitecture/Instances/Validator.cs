using System.Collections.Generic;
using EasyArchitecture.Common;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class Validator
    {
        private readonly EasyConfig _easyCofig;
        private readonly IValidatorPlugin _plugin;

        internal Validator(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            _plugin = (IValidatorPlugin)_easyCofig.Plugins[typeof(IValidatorPlugin)];

            _plugin.Configure(_easyCofig.InfrastructureAssembly);
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
