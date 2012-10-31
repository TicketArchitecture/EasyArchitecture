using FluentNHibernate.Cfg.Db;
using EasyArchitecture.Data;

namespace Application4Test.Infrastructure.Repositories.Configuration
{
    public class NHibernateConfig : NHibernateConfiguration
    {
        public override IPersistenceConfigurer ConfigureDatabase()
        {
            return SQLiteConfiguration.Standard.UsingFile(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,  ConnectionString))
                .ShowSql();
        }


    }
}
