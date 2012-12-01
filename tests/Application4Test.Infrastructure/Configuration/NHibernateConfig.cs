using EasyArchitecture.Plugins.NHibernate;
using FluentNHibernate.Cfg.Db;

namespace Application4Test.Infrastructure.Configuration
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
