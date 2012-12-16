using System;
using System.Collections.Generic;
using EasyArchitecture.Runtime.Contracts;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Configuration.Expressions
{
    public static class FactoryInitializer
    {
        private static readonly List<Type> AllowedFactories=new List<Type>();
        private static readonly Dictionary<Type, Type> BuiltinPlugins = new Dictionary<Type, Type>();

        static FactoryInitializer()
        {
            //TODO: load all types that implements 2 required interfaces
            AllowedFactories.Add(typeof(ValidatorFactory));
        }

        public static void Exec(ConfigHelper configHelper)
        {
            foreach (var allowedFactory in AllowedFactories)
            {
                var factory = (IConfigurableFactory) Activator.CreateInstance(allowedFactory);
                factory.Configure(configHelper);
            }
        }
    }
}