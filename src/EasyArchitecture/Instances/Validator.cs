using System.Collections.Generic;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    internal class Validator
    {
        private readonly EasyConfig _easyCofig;

        internal Validator(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            //get plugin
            var plugin = (IValidatorPlugin)_easyCofig.Plugins[typeof(IValidatorPlugin)];

            //configure
            plugin.Configure(_easyCofig.InfrastructureAssembly);
        }


        internal List<string> GetMessages<T>(T entity)
        {
            //get plugin
            var plugin = (IValidatorPlugin)_easyCofig.Plugins[typeof(IValidatorPlugin)];

            //execute
            return plugin.Validate(entity);
        }

        internal void IsValid<T>(T entity)
        {
            //get plugin
            var plugin = (IValidatorPlugin)_easyCofig.Plugins[typeof(IValidatorPlugin)];

            //execute
            var messages = plugin.Validate(entity);
            if (messages.Count != 0)
                throw new InvalidEntityException(messages.ToArray());
        }

    }
}
