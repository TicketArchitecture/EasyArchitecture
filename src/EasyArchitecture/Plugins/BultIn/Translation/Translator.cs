using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Plugins.Contracts.Translation;

namespace EasyArchitecture.Plugins.BultIn.Translation
{
    internal class Translator : ITranslator
    {
        private readonly List<TypeMap> _mappedTypes;

        public Translator(List<TypeMap> mappedTypes)
        {
            _mappedTypes = mappedTypes;
        }

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

        private object TranslateObject(object source, object target)
        {
            var typeMap = _mappedTypes.Find(m => m.Source == source.GetType() && m.Target == target.GetType());
            if (typeMap != null)
            {
                var func = typeMap.DeclaredMap;
                return func.GetType().InvokeMember("Invoke", BindingFlags.InvokeMethod, null, func, new object[] { source, target });
            }

            foreach (var property in source.GetType().GetProperties())
            {
                var value = property.GetValue(source, null);
                if (value == null) continue;

                var targetProperty = target.GetType().GetProperty(property.Name);
                if (targetProperty == null) continue;

                value = ConvertValue(property.PropertyType, targetProperty.PropertyType, value);

                targetProperty.SetValue(target, value, null);
            }
            return target;
        }

        private object ConvertValue(Type source, Type target, object value)
        {
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

            if (target.IsClass && source.IsClass)
            {
                value = TranslateObject(value, TypeManager.InstanceCreator(target));
            }

            value = Convert.ChangeType(value, target);

            return value;
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

        private IList TranslateGenericList(object source, Type target)
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
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
