using System;
using System.Collections.Generic;

namespace EasyArchitecture.Core
{
    internal class ThreadContext
    {
        internal string Name;
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();
        internal void SetInstance<T>(T instance)
        {
            _instances[typeof(T)] = instance;
        }

        internal T GetInstance<T>()
        {
            var type = typeof(T);
            return _instances.ContainsKey(type) ? (T)_instances[type] : default(T);
        }

        internal  void Initialize()
        {
            _instances.Clear();
        }
    }
}