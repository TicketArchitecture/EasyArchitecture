using System;
using System.Collections.Generic;
using System.Threading;

namespace EasyArchitecture.Core
{
    internal class ThreadContext
    {
        private static readonly string ConfigurationNameKey = typeof(ThreadContext).Name;
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();
        internal string ConfigurationName;
        internal Guid Identifier;

        private ThreadContext()
        {
        }

        internal static ThreadContext GetCurrent()
        {
            var slot = Thread.GetNamedDataSlot(ConfigurationNameKey);
            return (ThreadContext)Thread.GetData(slot);
        }

        internal static void Create(string moduleName)
        {
            var context = new ThreadContext { ConfigurationName = moduleName };
            var slot = Thread.GetNamedDataSlot(ConfigurationNameKey);
            Thread.SetData(slot, context);
        }

        internal void SetInstance<T>(T instance)
        {
            _instances[typeof(T)] = instance;
        }

        internal T GetInstance<T>()
        {
            var type = typeof(T);
            return _instances.ContainsKey(type) ? (T)_instances[type] : default(T);
        }

        internal void Initialize()
        {
            Identifier = Guid.NewGuid();
            _instances.Clear();
        }
    }
}