using System;
using EasyArchitecture.Plugins.NHibernate.Persistence;
using FluentNHibernate.Cfg.Db;

namespace EasyArchitecture.Plugins.NHibernate.Tests.Stuff
{
    public class NHibernateConfig : INHibernateConfiguration
    {
        public IPersistenceConfigurer ConfigureDatabase()
        {
            return
                SQLiteConfiguration.Standard.UsingFile(
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Stuff", "dogdb.db")
                ).ShowSql();
        }
    }
}
