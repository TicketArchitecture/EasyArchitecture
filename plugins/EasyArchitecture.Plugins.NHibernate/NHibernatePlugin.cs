using System;
using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate;

namespace EasyArchitecture.Plugins.NHibernate
{
    public class NHibernatePlugin : IPersistencePlugin
    {
        private static readonly Dictionary<string, PersistenceConfiguration> PersitenceConfigurations = new Dictionary<string, PersistenceConfiguration>();
        private static readonly Dictionary<string, ISessionFactory> SessionFactories = new Dictionary<string, ISessionFactory>();
        private static readonly object PersistenceLock = new object();

        public void Configure(string moduleName, Assembly assembly)
        {
            var nhibernateConfigurationType = Array.Find(assembly.GetExportedTypes(), t => typeof(INHibernateConfiguration).IsAssignableFrom(t));

            INHibernateConfiguration nhibernateConfiguration = null;
            if (nhibernateConfigurationType != null)
            {
                nhibernateConfiguration = (INHibernateConfiguration)nhibernateConfigurationType.Assembly.CreateInstance(nhibernateConfigurationType.FullName);
            }

            var config = new PersistenceConfiguration
                             {
                                 MappingAssembly = assembly,
                                 NHibernateConfiguration = nhibernateConfiguration
                             };

            //PersitenceConfigurations.Add(businessModuleName, config);
            PersitenceConfigurations[moduleName] = config;

            //Log.To(typeof(PersistenceManagerInitializer)).Message("Assigned connection string [{0}] to [{1}] business module", connectionString, businessModuleName).Debug();
            //Log.To(typeof(PersistenceManagerInitializer)).Message("Mapped [{0}] to persistence", assembly).Debug();
            //Log.To(typeof(PersistenceManagerInitializer)).Message("Loaded [{0}] to configure persistence", nhibernateConfiguration).Debug();            
        }

        private static ISessionFactory GetSessionFactory(string moduleName)
        {
            lock (PersistenceLock)
            {
                if (SessionFactories.ContainsKey(moduleName))
                    return SessionFactories[moduleName];

                var config = GetConfiguration(moduleName);

                var sessionFactory = GetConfiguredSessionFactory(config);

                SessionFactories.Add(moduleName, sessionFactory);

                return sessionFactory;
            }
        }

        public void BeginTransaction(object persistenceSession)
        {
            var aaa = persistenceSession as ISession;
            if (aaa != null) aaa.BeginTransaction();
        }

        public void CommitTransaction(object persistenceSession)
        {
            var aaa = persistenceSession as ISession;
            if (aaa != null)
            {
                aaa.Transaction.Commit();
                aaa.Flush();
                aaa.Close();
            }
        }

        public void RollbackTransaction(object persistenceSession)
        {
            var aaa = persistenceSession as ISession;
            if (aaa != null)
            {
                aaa.Transaction.Rollback();
                aaa.Close();
            }
        }

        public object GetSession(string moduleName)
        {
            return GetSessionFactory(moduleName).OpenSession();
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

        private static PersistenceConfiguration GetConfiguration(string moduleName)
        {
            return PersitenceConfigurations[moduleName];
        }
    }
}
