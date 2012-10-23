using FluentNHibernate.Cfg.Db;

namespace EasyArchitecture.Data
{
    public abstract class NHibernateConfiguration
    {
        public string ConnectionString { get; set; }
        public abstract IPersistenceConfigurer ConfigureDatabase();
    }
}