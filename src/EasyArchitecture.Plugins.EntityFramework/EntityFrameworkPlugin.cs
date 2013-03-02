using System;
using System.Data.Entity;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Persistence;

namespace EasyArchitecture.Plugins.EntityFramework
{
    public class EntityFrameworkPlugin :AbstractPlugin, IPersistencePlugin
    {
        private DbContext _dbContext;
     
        public IPersistence GetInstance()
        {
            return new EntityFrameworkPersistence(_dbContext);
        }

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            var assembly = moduleAssemblies.InfrastructureAssembly;

            var dbContextType = Array.Find(assembly.GetExportedTypes(), t => t.IsSubclassOf(typeof(DbContext)));
            if (dbContextType != null)
            {
                _dbContext = (DbContext) dbContextType.Assembly.CreateInstance(dbContextType.FullName);
            }
        }
    }
  

}
