using System;
using System.Threading;
using EasyArchitecture.Caching.Instance;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.Log.Instance;
using EasyArchitecture.Storage.Instance;
using EasyArchitecture.Translation.Instance;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Runtime
{
    internal static class LocalThreadStorage
    {
        private const string ModuleNameKey = "bmn";
        //private const string PersistenceSessionKey = "ps";

        internal static string GetCurrentModuleName()
        {
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            return (string)Thread.GetData(slot);
        }

        internal static void SetCurrentModuleName(string moduleName)
        {
            ClearThread();
            var slot = Thread.GetNamedDataSlot(ModuleNameKey);
            Thread.SetData(slot, moduleName);
        }

        internal static void SetInstance<T>(T instance)
        {
            var name = typeof (T).Name;
            var slot = Thread.GetNamedDataSlot(name);
            Thread.SetData(slot, instance);
        }
        internal static T GetInstance<T>()
        {
            var name = typeof(T).Name;
            var slot = Thread.GetNamedDataSlot(name);
            return (T)Thread.GetData(slot);
        }

        internal static void SetCurrentModuleName(Type type)
        {
            var moduleName = AssemblyManager.RemoveAssemblySufix(type.Namespace);
            SetCurrentModuleName(moduleName);
        }

        //internal static object RecoverSession(string moduleName)
        //{
        //    var slot = Thread.GetNamedDataSlot(PersistenceSessionKey + moduleName);
        //    return Thread.GetData(slot);
        //}

        //internal static void ClearSession(string moduleName)
        //{
        //    var slot = Thread.GetNamedDataSlot(PersistenceSessionKey + moduleName);
        //    Thread.SetData(slot, null);
        //}

        //internal static void StoreSession(string moduleName, object persistenceSession)
        //{
        //    var slot = Thread.GetNamedDataSlot(PersistenceSessionKey + moduleName);
        //    Thread.SetData(slot, persistenceSession);
        //}

        private static void ClearThread()
        {
            //TODO: feio, mas o unit test mantem/reutiliza a thread
            Thread.FreeNamedDataSlot(typeof (Validator).Name);
            Thread.FreeNamedDataSlot(typeof(Cache).Name);
            Thread.FreeNamedDataSlot(typeof(Translator).Name);
            Thread.FreeNamedDataSlot(typeof(Logger).Name);
            Thread.FreeNamedDataSlot(typeof(Storer).Name);
            Thread.FreeNamedDataSlot(typeof(Container).Name);
            Thread.FreeNamedDataSlot(typeof(Persistence.Instance.Persistence).Name);
        }
    }
}