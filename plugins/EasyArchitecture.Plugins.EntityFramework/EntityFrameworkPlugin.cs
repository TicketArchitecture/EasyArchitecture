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

        public void Configure(string businessModuleName, Assembly assembly)
        {
            var nhibernateConfigurationType = Array.Find(assembly.GetExportedTypes(), t => t.IsSubclassOf(typeof(DbContext)));
            if (nhibernateConfigurationType != null)
            {
                //DbContextTypes.Add(businessModuleName,nhibernateConfigurationType);
                DbContextTypes[businessModuleName] = nhibernateConfigurationType;
            }
        }

        private static Type GetSessionFactory(string businessModuleName)
        {
            lock (PersistenceLock)
            {
                if (DbContextTypes.ContainsKey(businessModuleName))
                    return DbContextTypes[businessModuleName];

                return null;
            }
        }

        public void BeginTransaction(object session)
        {
            //var aaa = session as DbContext;
            //if (aaa != null) aaa..BeginTransaction();
        }

        public void CommitTransaction(object session)
        {
            var aaa = session as DbContext;
            if (aaa != null)
            {
                aaa.SaveChanges();
            }
        }

        public void RollbackTransaction(object session)
        {
            var aaa = session as DbContext;
            //if (aaa != null)
            //{
            //    aaa..Transaction.Rollback();
            //    aaa.Close();
            //}
        }

        public object GetSession(string moduleName)
        {
            var nhibernateConfigurationType = GetSessionFactory(moduleName);
            var context= (DbContext)nhibernateConfigurationType.Assembly.CreateInstance(nhibernateConfigurationType.FullName);
            return context;
        }
    }
}
