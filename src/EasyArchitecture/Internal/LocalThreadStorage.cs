using System;
using System.Threading;

namespace EasyArchitecture.Internal
{
    //TODO: must be internal
    public static class LocalThreadStorage
    {
        private const string BusinessModuleNameKey = "bmn";
        private const string NHibernateSession = "nhs";

        //TODO: must be internal
        public static string GetCurrentBusinessModuleName()
        {
            var slot = Thread.GetNamedDataSlot(BusinessModuleNameKey);
            return (string)Thread.GetData(slot);
        }

        //TODO: must be internal
        public static void SetCurrentBusinessModuleName(string businessModuleName)
        {
            var slot = Thread.GetNamedDataSlot(BusinessModuleNameKey);
            Thread.SetData(slot, businessModuleName);
        }

        //TODO: must be internal
        public static void SetCurrentBusinessModuleName(Type type)
        {
            var moduleName = AssemblyManager.RemoveAssemblySufix(type.Namespace);
            var slot = Thread.GetNamedDataSlot(BusinessModuleNameKey);
            Thread.SetData(slot, moduleName);
        }


        internal static object RecoverSession(string businessModuleName)
        {
            var slot = Thread.GetNamedDataSlot(NHibernateSession + businessModuleName);
            return Thread.GetData(slot);
        }

        internal static void ClearSession(string businessModuleName)
        {
            var slot = Thread.GetNamedDataSlot(NHibernateSession + businessModuleName);
            Thread.SetData(slot, null);
        }

        internal static void StoreSession(string businessModuleName, object session)
        {
            var slot = Thread.GetNamedDataSlot(NHibernateSession + businessModuleName);
            Thread.SetData(slot, session);
        }

    }
}