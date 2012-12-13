using System.Reflection;

namespace EasyArchitecture.Persistence.Plugin.Contracts
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