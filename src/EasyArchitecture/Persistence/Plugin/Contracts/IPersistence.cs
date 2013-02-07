namespace EasyArchitecture.Persistence.Plugin.Contracts
{
    public interface IPersistence
    {
        void BeginTransaction(ISession session);
        void CommitTransaction(ISession session);
        void RollbackTransaction(ISession session);
        ISession GetSession(string moduleName);
    }
}