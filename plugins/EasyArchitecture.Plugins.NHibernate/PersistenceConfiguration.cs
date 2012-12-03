using System.Reflection;

namespace EasyArchitecture.Plugins.NHibernate
{
    internal class PersistenceConfiguration
    {
        internal Assembly MappingAssembly;
        internal INHibernateConfiguration NHibernateConfiguration;
    }
}