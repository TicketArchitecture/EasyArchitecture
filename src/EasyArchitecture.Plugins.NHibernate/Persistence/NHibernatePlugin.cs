using System;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Plugins.Contracts.Persistence;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace EasyArchitecture.Plugins.NHibernate.Persistence
{
    public class NHibernatePlugin : Plugin, IPersistencePlugin
    {
        private ISessionFactory _sessionFactory;
        private object _instance;
        
        public IPersistence GetInstance()
        {
            return new NHibernatePersistence(_sessionFactory.OpenSession());
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var nhibernateConfiguration =  _instance
                ?? GetNHibernateConfiguration<INHibernateFluentlyConfig>(pluginConfiguration.InfrastructureAssembly)
                ?? (object)GetNHibernateConfiguration<INHibernateCodeConfig>(pluginConfiguration.InfrastructureAssembly);

            _sessionFactory = GetSessionFactory(nhibernateConfiguration,pluginConfiguration.InfrastructureAssembly);

        }

        private static ISessionFactory GetSessionFactory(object nhibernateConfiguration, Assembly assembly)
        {
            return nhibernateConfiguration is INHibernateFluentlyConfig
                       ? FluentlyMapped((INHibernateFluentlyConfig) nhibernateConfiguration, assembly)
                       : (nhibernateConfiguration is INHibernateCodeConfig
                              ? ByCodeMapped((INHibernateCodeConfig) nhibernateConfiguration, assembly)
                              : null);
        }

        private static ISessionFactory FluentlyMapped(INHibernateFluentlyConfig nhibernateConfiguration,Assembly assembly)
        {
                       return Fluently.Configure()
                             .Database(nhibernateConfiguration.ConfigureDatabase())
                             .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                             .BuildConfiguration()
                             .BuildSessionFactory();
        }

        private static ISessionFactory ByCodeMapped(INHibernateCodeConfig nhibernateConfiguration, Assembly assembly)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(assembly.GetExportedTypes()
               .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                           t.BaseType.GetGenericTypeDefinition() == typeof(ClassMapping<>)));

            var configure = new global::NHibernate.Cfg.Configuration();

            nhibernateConfiguration.AddDataBaseIntegrationInfo(configure);

            configure.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            return configure.BuildSessionFactory();
        }

        private static T GetNHibernateConfiguration<T>(Assembly assembly)
        {
            var nhibernateConfigurationType = Array.Find(assembly.GetExportedTypes(), typeof(T).IsAssignableFrom);

            return nhibernateConfigurationType == null ?
                default(T) : (T)nhibernateConfigurationType.Assembly.CreateInstance(nhibernateConfigurationType.FullName);
        }
        
        internal void SetConfigurationInstance(object instance)
        {
            _instance = instance;
        }
    }
}
