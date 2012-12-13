using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class Container
    {
        //TODO: better not be statick (all plugins are per module)
        private static readonly Dictionary<Type, Type> RegisteredTypes = new Dictionary<Type, Type>();

        public static void Register<T, U>() where U:T
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            var interfaceType = typeof(T);

            //verify if T is interface, throw NotInterfaceException

            if (RegisteredTypes.ContainsKey(interfaceType))
            {
                RegisteredTypes[interfaceType] = typeof(U);
            }
            else
            {
                RegisteredTypes.Add(interfaceType, typeof(U));
            }
        }

        public static T Resolve<T>()  
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();


            //localizar na colletion
            var interfaceType = typeof(T);

            //verify if T is interface, throw NotInterfaceException


            //TODO: create a NotRegisteredException
            if (!RegisteredTypes.ContainsKey(interfaceType))
                throw new ArgumentException("Type not registered", interfaceType.ToString());

            var implementationType = RegisteredTypes[interfaceType];

            //verificar dependencias no constructor
            var constructors =  implementationType.GetConstructors(BindingFlags.Public);

            //tem constructor() public?
            var constructorDefault =  Array.Find(constructors, c => c.GetParameters().Length == 0);

            
            T instance = default(T);

            //se houver constructor default, instanciar
            if(constructorDefault != null || constructors.Length==0)
                instance = (T) implementationType.Assembly.CreateInstance(implementationType.FullName);


            ////take the first
            //var constructor = constructors[0];

            //foreach (var parameterInfo in constructor.GetParameters())
            //{
            //    var paramType = parameterInfo.GetType();
            //    //var paramInstance = this.

            //}
                //se houver dependencias
            //loop pelas dependencias (recursividade)
            //ateh completa-las

            //dependencias completas, instanciar
            

            //se for marcado interception, gerar proxy
            //var proxy = ProxyFactory.NewInstance(instance);


            //devolver
            return instance;
        }

        internal static Type Verify<T>()
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            //localizar na colletion
            var interfaceType = typeof(T);

            //TODO: create a NotRegisteredException
            if (!RegisteredTypes.ContainsKey(interfaceType))
                throw new ArgumentException("Type not registered", interfaceType.ToString());

            return RegisteredTypes[interfaceType];
        }

        public static void RegisterType(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsInterface)
                throw new NotInterfaceException();

            //var interfaceType = typeof(T);

            //verify if T is interface, throw NotInterfaceException

            if (RegisteredTypes.ContainsKey(interfaceType))
            {
                RegisteredTypes[interfaceType] = implementationType;
            }
            else
            {
                RegisteredTypes.Add(interfaceType, implementationType);
            }
        }
    }
}
