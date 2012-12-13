using System.Reflection;

namespace EasyArchitecture.Plugins.BuiltIn.Persistence
{
    public class PersistencePlugin:IPersistencePlugin
    {
        public void Configure(string moduleName, Assembly assembly)
        {
            //load mini map ???

        }

        public void BeginTransaction(object session)
        {
            var mySession = session as Session;
            mySession.BeginTransaction();
        }

        public void CommitTransaction(object session)
        {
            var mySession = session as Session;
            mySession.CommitTransaction();
        }

        public void RollbackTransaction(object session)
        {
            var mySession = session as Session;
            mySession.RollbackTransaction();
        }

        public object GetSession(string moduleName)
        {
            
            //cria novo uow
            var session = new Session();
            return session;


        }
    }
}