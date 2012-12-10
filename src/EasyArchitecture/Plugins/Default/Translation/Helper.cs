using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyArchitecture.Plugins.Default.Translation
{
    public static class Helper
    {
        public static object GetDefaultValue(Type type)
        {
            return !type.IsValueType ? null : Activator.CreateInstance(type);
        }
        public static bool IsGenericList(Type type)
        {
            Type genericListInteface = type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));
            return genericListInteface != null;
        }
    }
}