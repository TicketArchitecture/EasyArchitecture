using System.Reflection;

namespace EasyArchitecture.Plugins
{
    public interface IPersistencePlugin
    {
        void Configure(string moduleName, Assembly assembly);
        void BeginTransaction(object session);
        void CommitTransaction(object session);
        void RollbackTransaction(object session);
        object GetSession(string moduleName);
    }
}