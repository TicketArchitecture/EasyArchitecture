using System.Collections.Generic;
using FluentNHibernate.Cfg;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Internal;
using NHibernate;

namespace EasyArchitecture.Data
{
    public static class PersistenceManager
    {
        private static readonly Dictionary<string, ISessionFactory> SessionFactories = new Dictionary<string, ISessionFactory>();
        private static readonly object PersistenceLock = new object();

        internal static ISession GetSession()
        {
            var moduleName = LocalThreadStorage.GetCurrentBusinessModuleName();
            var session =  (ISession)LocalThreadStorage.RecoverSession(moduleName) ?? GetSessionFactory(moduleName).OpenSession();
            
            Log.To((typeof(PersistenceManager))).Message("Get session [{0}] for [{1}]",session.GetHashCode(),moduleName).Debug();

            return session;
        }

        internal static void BeginTransaction(string businessModuleName)
        {
            var session = GetSession();
            session.BeginTransaction();

            LocalThreadStorage.StoreSession(businessModuleName, session);

            Log.To((typeof(PersistenceManager))).Message("Started Transaction to session [{0}]",session.GetHashCode()).Debug();

        }

        internal static void CommitTransaction(string businessModuleName)
        {
            var session = (ISession)LocalThreadStorage.RecoverSession(businessModuleName);
            session.Transaction.Commit();
            session.Flush();
            session.Close();
            LocalThreadStorage.ClearSession(businessModuleName);

            Log.To((typeof(PersistenceManager))).Message("Commited Transaction to session [{0}]", session.GetHashCode()).Debug();
        }

        internal static void RollbackTransaction(string businessModuleName)
        {
            var session = (ISession)LocalThreadStorage.RecoverSession(businessModuleName);
            session.Transaction.Rollback();
            session.Close();
            LocalThreadStorage.ClearSession(businessModuleName);

            Log.To((typeof(PersistenceManager))).Message("Rolledback Transaction to session [{0}]", session.GetHashCode()).Debug();
        }

        private static ISessionFactory GetSessionFactory(string businessModuleName)
        {
            lock (PersistenceLock)
            {

                Log.To((typeof(PersistenceManager))).Message("Get Session Factory for [{0}]",businessModuleName).Debug();

                if (SessionFactories.ContainsKey(businessModuleName))
                    return SessionFactories[businessModuleName];

                var config = PersistenceManagerInitializer.GetConfiguration(businessModuleName);

                var sessionFactory = GetConfiguredSessionFactory(config);

                SessionFactories.Add(businessModuleName, sessionFactory);

                return sessionFactory;
            }
        }

        private static ISessionFactory GetConfiguredSessionFactory(PersistenceConfiguration persistenceConfiguration)
        {
            return Fluently.Configure()
                .Database(persistenceConfiguration.NHibernateConfiguration.ConfigureDatabase())
                .ProxyFactoryFactory("NHibernate.Bytecode.DefaultProxyFactoryFactory, NHibernate")
                .Mappings(m => m.FluentMappings.AddFromAssembly(persistenceConfiguration.MappingAssembly))
                .BuildConfiguration()
                .BuildSessionFactory();
        }
    }
}
