using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Runtime;
using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Plugin.BultIn
{
    internal class Translator : ITranslator
    {
        private static readonly List<TypeMap> MappedTypes = new List<TypeMap>();

        public T1 Translate<T, T1>(T source) 
        {
            if (typeof(T).IsValueType || typeof(T1).IsValueType)
                throw new ArgumentException("Just class can be translated", "source");

            if (source == null)
                return default(T1);

            T1 target;

            if (TypeManager.IsGenericList<T>() && TypeManager.IsGenericList<T1>())
            {
                target = TypeManager.CreateGenericList<T1>();

            }
            else
            {
                target = TypeManager.InstanceCreator<T1>();
            }

            return Translate(source, target);
        }

        public T1 Translate<T, T1>(T source, T1 target)
        {
            if (typeof(T).IsValueType || typeof(T1).IsValueType)
                throw new ArgumentException("Just class can be translated", "source");

            if (source == null)
                return target;

            if (TypeManager.IsGenericList<T>() && TypeManager.IsGenericList<T1>())
            {
                var targetList = (IList)target;
                var sourceList = (IEnumerable)source;

                var targetGenericType = ThisIsGenericList(target);
                foreach (var item in sourceList)
                {
                    targetList.Add(TranslateObject(item, TypeManager.InstanceCreator(targetGenericType)));
                }
                target = (T1)targetList;
            }
            else
            {
                target = (T1)TranslateObject(source, target);
            }

            return target;
        }

        private static object TranslateObject<T, T1>(T source, T1 target)
        {
            //se ha mapeamento manual, executa delegate
            var typeMap = MappedTypes.Find(m => m.Source == typeof(T) && m.Target == typeof(T1));
            if (typeMap != null)
            {
                var func = (Func<T, T1, T1>)typeMap.DeclaredMap;
                return func(source, target);
            }

            //se nao ha regra para mapeamento, executa mapeamento por convencao

            //look @ properties
            foreach (var property in source.GetType().GetProperties())
            {
                //get source property value
                var value = property.GetValue(source, null);
                if (value == null) continue;

                //get target property
                var targetProperty = target.GetType().GetProperty(property.Name);
                if (targetProperty == null) continue;

                //convert value
                value = ConvertValue(property.PropertyType, targetProperty.PropertyType, value);

                //apply value
                targetProperty.SetValue(target, value, null);
            }
            return target;
        }

        private static object ConvertValue(Type source, Type target, object value)
        {
            //TODO: teste
            //verificar se é lista genérica, se for, manda traduzir os itens da lista
            if (ThisIsGenericList(value) != null)
            {
                value = TranslateGenericList(value, target);
                return value;
            }

            if (source == target || source.IsAssignableFrom(target))
            {
                return value;
            }

            if (source == typeof(string) && string.IsNullOrEmpty((string)value))
            {
                value = GetDefaultValue(target);
            }

            if (target.IsGenericType)
            {
                target = target.GetGenericArguments()[0];
            }

            //TODO: verificar
            //falta a condicao de obj->obj
            if (target.Name.Contains("DTO") || target.Name.Contains("TO") || source.Name.Contains("DTO") || source.Name.Contains("TO"))
            {
                value = TranslateObject(value, TypeManager.InstanceCreator(target));
            }

            value = Convert.ChangeType(value, target);

            return value;
        }

        public static void MapType<T, TD>(Func<T, TD, TD> func)
        {
            MappedTypes.Add(new TypeMap() { Source = typeof(T), Target = typeof(TD), DeclaredMap = func });
        }

        private static Type ThisIsGenericList(Type type)
        {
            Type typeGeneric = null;

            if (TypeManager.IsGenericList(type))
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();
                if ((genericTypeDefinition == typeof(IList<>)) || (genericTypeDefinition == typeof(List<>)))
                {
                    typeGeneric = type.GetGenericArguments().FirstOrDefault();
                }
            }

            return typeGeneric;
        }

        private static Type ThisIsGenericList(object obj)
        {
            return ThisIsGenericList(obj.GetType());
        }

        private static IList TranslateGenericList(object source, Type target)
        {
            IList targetList = null;

            var sourceGenericType = ThisIsGenericList(source);
            var targetGenericType = ThisIsGenericList(target);
            if (sourceGenericType != null)
            {
                var sourceList = (IEnumerable)source;
                targetList = (IList)TypeManager.CreateGeneric(typeof(List<>), targetGenericType);

                foreach (var item in sourceList)
                {
                    targetList.Add(TranslateObject(item, TypeManager.InstanceCreator(targetGenericType)));
                }
            }
            return targetList;
        }

        private static object GetDefaultValue(Type type)
        {
            return !type.IsValueType ? null : Activator.CreateInstance(type);
        }

    }
}
