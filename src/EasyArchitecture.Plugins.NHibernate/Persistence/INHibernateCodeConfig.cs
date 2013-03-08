namespace EasyArchitecture.Plugins.NHibernate.Persistence
{
    public interface INHibernateCodeConfig
    {
        void AddDataBaseIntegrationInfo(global::NHibernate.Cfg.Configuration config);
    }
}