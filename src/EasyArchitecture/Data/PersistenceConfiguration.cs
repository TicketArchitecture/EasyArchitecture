using System.Reflection;

namespace EasyArchitecture.Data
{
    internal class PersistenceConfiguration
    {
        public string Name;
        public string ConnectionString;
        public Assembly MappingAssembly;
        public NHibernateConfiguration NHibernateConfiguration;
    }
}