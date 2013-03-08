using System;
using EasyArchitecture.Plugins.NHibernate.Persistence;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace EasyArchitecture.Plugins.NHibernate.Tests.Stuff.Code
{
    public class CodeNHibernateConfig : INHibernateCodeConfig
    {
        private readonly string _dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Stuff", "dogdb.db");

        public void AddDataBaseIntegrationInfo(global::NHibernate.Cfg.Configuration config)
        {
            config.DataBaseIntegration(db =>
            {
                db.ConnectionString = string.Format("Data Source={0};Version=3;New=True;", _dbPath);
                db.Driver<SQLite20Driver>();
                db.Dialect<SQLiteDialect>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                // enabled for testing
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });
        }
    }
}
