using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Diagnostic;


namespace EasyArchitecture.Data
{
    internal static class PersistenceManagerInitializer
    {
        private static readonly Dictionary<string,PersistenceConfiguration> PersitenceConfigurations = new Dictionary<string, PersistenceConfiguration>();

        internal static void Configure(string businessModuleName, string connectionString, Assembly assembly)
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

            Log.To(typeof(PersistenceManagerInitializer)).Message("Assigned connection string [{0}] to [{1}] business module", connectionString, businessModuleName).Debug();
            Log.To(typeof(PersistenceManagerInitializer)).Message("Mapped [{0}] to persistence", assembly).Debug();
            Log.To(typeof(PersistenceManagerInitializer)).Message("Loaded [{0}] to configure persistence", nhibernateConfiguration).Debug();            
        }

        internal static PersistenceConfiguration GetConfiguration(string businessModuleName)
        {
            return PersitenceConfigurations[businessModuleName];
        }

    }
}