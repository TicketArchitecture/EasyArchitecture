//using System.Collections.Generic;
//using EasyArchitecture.Configuration.Instance;
//using EasyArchitecture.Validation.Plugin.Contracts;

//namespace EasyArchitecture.Validation.Instance
//{
//    internal class Validator
//    {
//        private readonly ModuleConfiguration _easyCofig;
//        private readonly IValidatorPlugin _plugin;

//        internal Validator(ModuleConfiguration easyCofig)
//        {
//            _easyCofig = easyCofig;

//            _plugin = (IValidatorPlugin)_easyCofig.Plugins[typeof(IValidatorPlugin)];

//            _plugin.Configure(_easyCofig.InfrastructureAssembly);
//        }


//        internal List<string> GetMessages<T>(T entity)
//        {
//            return _plugin.Validate(entity);
//        }

//        internal void IsValid<T>(T entity)
//        {
//            var messages = _plugin.Validate(entity);
//            if (messages.Count != 0)
//                throw new InvalidEntityException(messages.ToArray());
//        }
//    }
//}
