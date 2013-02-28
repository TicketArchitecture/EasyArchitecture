using System.Threading;

namespace EasyArchitecture.Runtime
{
    internal static class LocalThreadStorage
    {
        private static readonly string ModuleNameKey = typeof(ThreadContext).Name;

        internal static ThreadContext GetCurrentContext()
        {
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            return (ThreadContext)Thread.GetData(slot);
        }

        internal static void CreateContext(string moduleName)
        {
            var context = new ThreadContext { Name = moduleName };
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            Thread.SetData(slot, context);
        }
    }
}