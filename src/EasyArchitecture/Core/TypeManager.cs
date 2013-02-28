using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyArchitecture.Core
{
    internal class TypeManager
    {
        internal static object InstanceCreator(Type type)
        {
            return type.Assembly.CreateInstance(type.FullName);
        }

        internal static T InstanceCreator<T>()
        {
            return (T) InstanceCreator(typeof(T));
        }

        internal static object CreateGeneric(Type generic, Type innerType, params object[] args)
        {
            var specificType = generic.MakeGenericType(new[] { innerType });
            return Activator.CreateInstance(specificType, args);
        }

        internal static T CreateGenericList<T>()
        {
            var genericList = typeof (List<>);
            var genericType = ThisIsGenericList(typeof (T));
            var specificType = genericList.MakeGenericType(new[] { genericType });
            return (T) Activator.CreateInstance(specificType);
        }

        internal static object CreateGenericList(Type typeOfList)
        {
            var genericList = typeof(List<>);
            
            var specificType = genericList.MakeGenericType(new[] { typeOfList });
            return Activator.CreateInstance(specificType);
        }

        private static Type ThisIsGenericList(Type type)
        {
            Type typeGeneric = null;

            if (IsGenericList(type))
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();
                if ((genericTypeDefinition == typeof(IList<>)) || (genericTypeDefinition == typeof(List<>)))
                {
                    typeGeneric = type.GetGenericArguments().FirstOrDefault();
                }
            }

            return typeGeneric;
        }

        internal static bool IsGenericList(Type type)
        {
            return null != type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));
        }

        internal static bool IsGenericList<T>()
        {
            return IsGenericList(typeof(T));
        }

    }
}
