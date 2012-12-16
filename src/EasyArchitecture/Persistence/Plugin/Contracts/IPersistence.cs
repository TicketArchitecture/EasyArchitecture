namespace EasyArchitecture.Persistence.Plugin.Contracts
{
    public interface IPersistence
    {
        void BeginTransaction(object session);
        void CommitTransaction(object session);
        void RollbackTransaction(object session);
        object GetSession(string moduleName);
    }
}