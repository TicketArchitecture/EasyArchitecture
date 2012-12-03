using FluentNHibernate.Cfg.Db;

namespace EasyArchitecture.Plugins.NHibernate
{
    public interface INHibernateConfiguration
    {
        IPersistenceConfigurer ConfigureDatabase();
    }
}