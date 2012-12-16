using EasyArchitecture.Persistence.Plugin.Contracts;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    public class Persistence:IPersistence
    {
        public void BeginTransaction(object session)
        {
            throw new System.NotImplementedException();
        }

        public void CommitTransaction(object session)
        {
            throw new System.NotImplementedException();
        }

        public void RollbackTransaction(object session)
        {
            throw new System.NotImplementedException();
        }

        public object GetSession(string moduleName)
        {
            throw new System.NotImplementedException();
        }
    }
}
