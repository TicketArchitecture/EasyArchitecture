using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Persistence.Plugin.Contracts
{
    public static class Persistence
    {
        public static object GetSession()
        {
            return ConfigurationSelector.Selector().Persistence.GetSession();
        }

        public static void CommitTransaction()
        {
            ConfigurationSelector.Selector().Persistence.CommitTransaction();
        }

        public static void RollbackTransaction()
        {
            ConfigurationSelector.Selector().Persistence.RollbackTransaction();
        }

        public static void BeginTransaction()
        {
            ConfigurationSelector.Selector().Persistence.BeginTransaction();
        }
    }
}
