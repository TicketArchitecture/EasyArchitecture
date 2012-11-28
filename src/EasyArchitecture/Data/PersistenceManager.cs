using EasyArchitecture.Initialization;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Data
{
    public static class PersistenceManager
    {
        internal static object GetSession()
        {
            var moduleName = LocalThreadStorage.GetCurrentBusinessModuleName();
            var session =  LocalThreadStorage.RecoverSession(moduleName) ?? Bootstrap.PersistencePlugin.GetSession(moduleName);
            
            Log.To((typeof(PersistenceManager))).Message("Get session [{0}] for [{1}]",session.GetHashCode(),moduleName).Debug();

            return session;
        }

        internal static void BeginTransaction(string businessModuleName)
        {
            var session = GetSession();

            Bootstrap.PersistencePlugin.BeginTransaction(session);

            LocalThreadStorage.StoreSession(businessModuleName, session);

            Log.To((typeof(PersistenceManager))).Message("Started Transaction to session [{0}]",session.GetHashCode()).Debug();

        }

        internal static void CommitTransaction(string businessModuleName)
        {
            var session = LocalThreadStorage.RecoverSession(businessModuleName);

            Bootstrap.PersistencePlugin.CommitTransaction(session);

            LocalThreadStorage.ClearSession(businessModuleName);

            Log.To((typeof(PersistenceManager))).Message("Commited Transaction to session [{0}]", session.GetHashCode()).Debug();
        }

        internal static void RollbackTransaction(string businessModuleName)
        {
            var session = LocalThreadStorage.RecoverSession(businessModuleName);

            Bootstrap.PersistencePlugin.RollbackTransaction(session);

            LocalThreadStorage.ClearSession(businessModuleName);

            Log.To((typeof(PersistenceManager))).Message("Rolledback Transaction to session [{0}]", session.GetHashCode()).Debug();
        }

    }
}
