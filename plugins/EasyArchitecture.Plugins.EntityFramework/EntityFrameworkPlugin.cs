using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;

namespace EasyArchitecture.Plugins.EntityFramework
{
    public class EntityFrameworkPlugin : IPersistencePlugin
    {
        private static readonly Dictionary<string, Type> DbContextTypes = new Dictionary<string, Type>();
        private static readonly object PersistenceLock = new object();

        public void Configure(string moduleName, Assembly assembly)
        {
            var dbContextType = Array.Find(assembly.GetExportedTypes(), t => t.IsSubclassOf(typeof(DbContext)));
            if (dbContextType != null)
            {
                DbContextTypes[moduleName] = dbContextType;
            }
        }

        private static Type GetSessionFactory(string moduleName)
        {
            lock (PersistenceLock)
            {
                if (DbContextTypes.ContainsKey(moduleName))
                    return DbContextTypes[moduleName];

                return null;
            }
        }

        public void BeginTransaction(object persistenceSession)
        {
            //var aaa = session as DbContext;
            //if (aaa != null) aaa..BeginTransaction();
        }

        public void CommitTransaction(object persistenceSession)
        {
            var session = persistenceSession as DbContext;
            if (session != null)
            {
                session.SaveChanges();
            }
        }

        public void RollbackTransaction(object persistenceSession)
        {
            var session = persistenceSession as DbContext;
            //if (session != null)
            //{
            //    session..Transaction.Rollback();
            //    session.Close();
            //}
        }

        public object GetSession(string moduleName)
        {
            var dbContextType = GetSessionFactory(moduleName);
            var context = (DbContext)dbContextType.Assembly.CreateInstance(dbContextType.FullName);
            return context;
        }
    }
}
