using System;
using System.Collections.Generic;
using System.Threading;

namespace EasyArchitecture.Core
{
    internal class ThreadContext
    {
        private static readonly string ModuleNameKey = typeof(ThreadContext).Name;
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();
        internal string Name;

        private ThreadContext()
        {
        }

        internal static ThreadContext GetCurrent()
        {
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            return (ThreadContext)Thread.GetData(slot);
        }

        internal static void Create(string moduleName)
        {
            var context = new ThreadContext { Name = moduleName };
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
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
            _instances.Clear();
        }
    }
}