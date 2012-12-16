using System;
using System.Collections.Generic;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class Container : IContainer
    {
        private readonly Dictionary<Type, Type> _registeredTypes = new Dictionary<Type, Type>();

        public void Register<T, T1>() where T1 : T
        {
            RegisterType(typeof (T), typeof (T1));
        }

        public void Register(Type interfaceType, Type implementationType, bool useInterception)
        {
            RegisterType(interfaceType, implementationType);
        }

        private void RegisterType(Type interfaceType, Type implementationType)
        {
            if (_registeredTypes.ContainsKey(interfaceType))
            {
                _registeredTypes[interfaceType] = implementationType;
            }
            else
            {
                _registeredTypes.Add(interfaceType, implementationType);
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
            var implementationType = _registeredTypes[interfaceType];


            /*-------------
             * BUILD
             * ------------*/

            //todo trabalho para devolver esse kra preenchido
            object instance = null;

            //-----------------------caminho feliz
            //ha 1 constructor default (parameterless)
            var constructors = implementationType.GetConstructors();

            //e se nao tiver nenhum constructor? //exception --> cannot build

            var parameterlessConstructor = Array.Find(constructors, c => c.GetParameters().Length == 0);
            if (parameterlessConstructor != null)
            {
                //instance = implementationType.Assembly.CreateInstance(implementationType.FullName);
                instance = Activator.CreateInstance(implementationType);
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
                instance = Activator.CreateInstance(implementationType, objects.ToArray());
            }

            //HACK: analisar qndo executar
            //se for marcado interception, gerar proxy
            //return ProxyFactory.NewInstance(instance);

            //devolver
            return instance;
        }
    }

}