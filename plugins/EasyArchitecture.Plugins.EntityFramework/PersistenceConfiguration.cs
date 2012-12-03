using System.Data.Entity;
using System.Reflection;

namespace EasyArchitecture.Plugins.EntityFramework
{
    internal class PersistenceConfiguration
    {
        internal Assembly MappingAssembly;
        internal DbContext DbContext;
    }
}