using EasyArchitecture.Plugins.NHibernate;
using FluentNHibernate.Cfg.Db;

namespace Application4Test.Infrastructure.Persistence.Configuration
{
    public class NHibernateConfig : INHibernateConfiguration
    {
        public IPersistenceConfigurer ConfigureDatabase()
        {
            return
                MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Application4Test")).
                    ShowSql();
        }
    }
}
