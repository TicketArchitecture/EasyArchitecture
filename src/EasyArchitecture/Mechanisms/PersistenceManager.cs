using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public static class PersistenceManager
    {
        public static object GetSession()
        {
            return EasyConfigurations.SelectorByThread().Persistence.GetSession();
        }

        public static void CommitTransaction()
        {
            EasyConfigurations.SelectorByThread().Persistence.CommitTransaction();
        }

        public static void RollbackTransaction()
        {
            EasyConfigurations.SelectorByThread().Persistence.RollbackTransaction();
        }

        public static void BeginTransaction()
        {
            EasyConfigurations.SelectorByThread().Persistence.BeginTransaction();
        }
    }
}
