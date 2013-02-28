using EasyArchitecture.Plugins.NHibernate.Persistence;
using FluentNHibernate.Cfg.Db;

namespace Exemplo.Produto.Infrastructure.Configuration.NHibernate
{
    public class NHibernateConfig : INHibernateConfiguration
    {
        public IPersistenceConfigurer ConfigureDatabase()
        {
            return
                MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Exemplo.Produto")).
                    ShowSql();
        }
    }
}
