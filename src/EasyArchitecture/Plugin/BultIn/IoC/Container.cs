using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Plugin.Contracts.IoC;

namespace EasyArchitecture.Plugin.BultIn.IoC
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
            var typeInfo = SearchType(interfaceType);

            var instance = GetInstance(typeInfo);

            return typeInfo.IsInteceptable ? ProxyFactory.NewInstance(instance) : instance;
        }

        private object GetInstance(TypeRegistry typeInfo)
        {
            var constructors = typeInfo.Type.GetConstructors();

            var parameterlessConstructor = Array.Find(constructors, c => c.GetParameters().Length == 0);
            if (parameterlessConstructor != null)
            {
                return Activator.CreateInstance(typeInfo.Type);
            }
            else
            {
                var constructor = constructors[0];
                return  Activator.CreateInstance(typeInfo.Type, constructor.GetParameters().Select(constructorParameter => this.Resolve(constructorParameter.ParameterType)).ToArray());
            }
        }

        private TypeRegistry SearchType(Type interfaceType)
        {
            if (!_registeredTypes.ContainsKey(interfaceType))
                throw new ArgumentException("Type not registered", interfaceType.ToString());

            return _registeredTypes[interfaceType];
        }
    }
}