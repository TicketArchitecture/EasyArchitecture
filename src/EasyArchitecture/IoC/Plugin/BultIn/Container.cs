using System;
using System.Collections.Generic;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class Container : IContainer
    {
        private readonly Dictionary<Type, TypeRegistry> _registeredTypes;

        public Container(Dictionary<Type, TypeRegistry> registeredTypes)
        {
            _registeredTypes = registeredTypes;
        }

        public void Register<T, T1>() where T1 : T
        {
            RegisterType(typeof (T), typeof (T1), false);
        }

        public void Register(Type interfaceType, Type implementationType, bool useInterception)
        {
            RegisterType(interfaceType, implementationType, useInterception);
        }

        private void RegisterType(Type interfaceType, Type implementationType, bool useInterception)
        {
            if (_registeredTypes.ContainsKey(interfaceType))
            {
                _registeredTypes[interfaceType] = new TypeRegistry(implementationType, useInterception);
            }
            else
            {
                _registeredTypes.Add(interfaceType, new TypeRegistry(implementationType, useInterception));
            }
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type interfaceType)
        {
            /*-----------------
             * RESOLVE T -> T1
             * ----------------*/
            //TODO: create a NotRegisteredException
            if (!_registeredTypes.ContainsKey(interfaceType))
                throw new ArgumentException("Type not registered", interfaceType.ToString());
            var typeInfo = _registeredTypes[interfaceType];


            /*-------------
             * BUILD
             * ------------*/
            object instance = null;

            var constructors = typeInfo.Type.GetConstructors();

            var parameterlessConstructor = Array.Find(constructors, c => c.GetParameters().Length == 0);
            if (parameterlessConstructor != null)
            {
                //ha 1 constructor default (parameterless)
                instance = Activator.CreateInstance(typeInfo.Type);
            }
            else
            {
                //ha 1 constructor com parametros
                var constructor = constructors[0];
                var objects = new List<object>();

                foreach (var constructorParameter in constructor.GetParameters())
                {
                    objects.Add(this.Resolve(constructorParameter.ParameterType));
                }

                instance = Activator.CreateInstance(typeInfo.Type, objects.ToArray());
            }

            return typeInfo.IsInteceptable ? ProxyFactory.NewInstance(instance) : instance;
        }
    }
}