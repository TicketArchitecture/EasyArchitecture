using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Persistence.Plugin.Contracts
{
    public static class Persistence
    {
        public static object GetSession()
        {
            return ConfigurationSelector.SelectorByThread().Persistence.GetSession();
        }

        public static void CommitTransaction()
        {
            ConfigurationSelector.SelectorByThread().Persistence.CommitTransaction();
        }

        public static void RollbackTransaction()
        {
            ConfigurationSelector.SelectorByThread().Persistence.RollbackTransaction();
        }

        public static void BeginTransaction()
        {
            ConfigurationSelector.SelectorByThread().Persistence.BeginTransaction();
        }
    }
}
