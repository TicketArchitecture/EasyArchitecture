using System;
using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate;

namespace EasyArchitecture.Plugins.NHibernate
{
    public class NHibernatePlugin : IPersistencePlugin
    {
        private static readonly Dictionary<string,PersistenceConfiguration> PersitenceConfigurations = new Dictionary<string, PersistenceConfiguration>();
        private static readonly Dictionary<string, ISessionFactory> SessionFactories =new Dictionary<string, ISessionFactory>();
        private static readonly object PersistenceLock = new object();

        public void Configure(string businessModuleName, string connectionString, Assembly assembly)
        {
                        var nhibernateConfigurationType = Array.Find(assembly.GetExportedTypes(), t => t.IsSubclassOf(typeof (NHibernateConfiguration)));

            NHibernateConfiguration nhibernateConfiguration = null;
            if (nhibernateConfigurationType != null)
            {
                nhibernateConfiguration = (NHibernateConfiguration)nhibernateConfigurationType.Assembly.CreateInstance(nhibernateConfigurationType.FullName);
                if (nhibernateConfiguration != null) nhibernateConfiguration.ConnectionString = connectionString;
            }

            var config = new PersistenceConfiguration
                             {
                                 Name = businessModuleName,
                                 ConnectionString = connectionString,
                                 MappingAssembly = assembly,
                                 NHibernateConfiguration = nhibernateConfiguration
                        };
            
            PersitenceConfigurations.Add(businessModuleName, config);

            //Log.To(typeof(PersistenceManagerInitializer)).Message("Assigned connection string [{0}] to [{1}] business module", connectionString, businessModuleName).Debug();
            //Log.To(typeof(PersistenceManagerInitializer)).Message("Mapped [{0}] to persistence", assembly).Debug();
            //Log.To(typeof(PersistenceManagerInitializer)).Message("Loaded [{0}] to configure persistence", nhibernateConfiguration).Debug();            
        }

        private static ISessionFactory GetSessionFactory(string businessModuleName)
        {
            lock (PersistenceLock)
            {
                if (SessionFactories.ContainsKey(businessModuleName))
                    return SessionFactories[businessModuleName];

                var config = GetConfiguration(businessModuleName);

                var sessionFactory = GetConfiguredSessionFactory(config);

                SessionFactories.Add(businessModuleName, sessionFactory);

                return sessionFactory;
            }
        }

        public void BeginTransaction(object session)
        {
            var aaa = session as ISession;
            if (aaa != null) aaa.BeginTransaction();
        }

        public void CommitTransaction(object session)
        {
            var aaa = session as ISession;
            if (aaa != null)
            {
                aaa.Transaction.Commit();
                aaa.Flush();
                aaa.Close();
            }
        }

        public void RollbackTransaction(object session)
        {
            var aaa = session as ISession;
            if (aaa != null)
            {
                aaa.Transaction.Rollback();
                aaa.Close();
                //aaa.Flush();
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

        private static PersistenceConfiguration GetConfiguration(string businessModuleName)
        {
            return PersitenceConfigurations[businessModuleName];
        }

    }
}
