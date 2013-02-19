using System;
using System.Collections.Generic;

namespace EasyArchitecture.Translation.Plugin.BultIn
{
    public abstract class MapRule
    {
        private readonly List<TypeMap> _mappedTypes = new List<TypeMap>();

        protected void AddMapRule<T, TD>(Func<T, TD, TD> func)
        {
            _mappedTypes.Add(new TypeMap() { Source = typeof(T), Target = typeof(TD), DeclaredMap = func });
        }

        internal IEnumerable<TypeMap> GetMapRules()
        {
            return _mappedTypes;
        }
    }
}
