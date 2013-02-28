using FluentNHibernate.Cfg.Db;

namespace EasyArchitecture.Plugins.NHibernate.Persistence
{
    public interface INHibernateConfiguration
    {
        IPersistenceConfigurer ConfigureDatabase();
    }
}