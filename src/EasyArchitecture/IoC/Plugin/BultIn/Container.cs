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
            //find impl
            //TODO: create a NotRegisteredException
            if (!_registeredTypes.ContainsKey(interfaceType))
                throw new ArgumentException("Type not registered", interfaceType.ToString());
            //resolve
            //var implementationType = _registeredTypes[interfaceType].Type;
            var typeInfo = _registeredTypes[interfaceType];


            /*-------------
             * BUILD
             * ------------*/

            //todo trabalho para devolver esse kra preenchido
            object instance = null;

            //-----------------------caminho feliz
            //ha 1 constructor default (parameterless)
            var constructors = typeInfo.Type.GetConstructors();

            //e se nao tiver nenhum constructor? //exception --> cannot build

            var parameterlessConstructor = Array.Find(constructors, c => c.GetParameters().Length == 0);
            if (parameterlessConstructor != null)
            {
                //instance = implementationType.Assembly.CreateInstance(implementationType.FullName);
                instance = Activator.CreateInstance(typeInfo.Type);
            }
            else
            {
                //-----------------------caminho triste
                //ha 1 constructor com parametros

                var constructor = constructors[0];
                //var constructorParameters = constructor.GetParameters();
                var objects = new List<object>();
                //foreach parameter -> call recursivelly
                foreach (var constructorParameter in constructor.GetParameters())
                {
                    //resolver parametros

                    objects.Add(this.Resolve(constructorParameter.ParameterType));
                }

                //instance = implementationType.Assembly.CreateInstance(implementationType.FullName,);
                instance = Activator.CreateInstance(typeInfo.Type, objects.ToArray());
            }

            return typeInfo.IsInteceptable ? ProxyFactory.NewInstance(instance) : instance;
        }
    }
}