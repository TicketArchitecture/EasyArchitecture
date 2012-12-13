using System;
using System.Threading;

namespace EasyArchitecture.Runtime
{
    //TODO: must be internal
    internal static class LocalThreadStorage
    {
        private const string ModuleNameKey = "bmn";
        private const string PersistenceSessionKey = "ps";

        //TODO: must be internal
        public static string GetCurrentModuleName()
        {
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            return (string)Thread.GetData(slot);
        }

        //TODO: must be internal
        public static void SetCurrentModuleName(string moduleName)
        {
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            Thread.SetData(slot, moduleName);
        }

        //TODO: must be internal
        public static void SetCurrentModuleName(Type type)
        {
            var moduleName = AssemblyManager.RemoveAssemblySufix(type.Namespace);
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            Thread.SetData(slot, moduleName);
        }


        internal static object RecoverSession(string moduleName)
        {
            var slot = Thread.GetNamedDataSlot(PersistenceSessionKey + moduleName);
            return Thread.GetData(slot);
        }

        internal static void ClearSession(string moduleName)
        {
            var slot = Thread.GetNamedDataSlot(PersistenceSessionKey + moduleName);
            Thread.SetData(slot, null);
        }

        internal static void StoreSession(string moduleName, object persistenceSession)
        {
            var slot = Thread.GetNamedDataSlot(PersistenceSessionKey + moduleName);
            Thread.SetData(slot, persistenceSession);
        }

    }
}