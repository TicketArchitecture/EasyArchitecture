using System.Collections.Generic;
using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    public class Validator
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


        public List<string> GetMessages<T>(T entity)
        {
            //get plugin
            var plugin = (IValidatorPlugin)_easyCofig.Plugins[typeof(IValidatorPlugin)];

            //execute
            return plugin.Validate(entity);
        }

        public void IsValid<T>(T entity)
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
