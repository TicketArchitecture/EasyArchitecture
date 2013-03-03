using System;
using EasyArchitecture.Plugins.NHibernate.Persistence;
using FluentNHibernate.Cfg.Db;

namespace Exemplo.Produto.Infrastructure.Configuration.NHibernate
{
    public class NHibernateConfig : INHibernateConfiguration
    {
        public IPersistenceConfigurer ConfigureDatabase()
        {
            return
                SQLiteConfiguration.Standard.UsingFile(System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "db", "sample.db"));
        }
    }
}
