using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Data
{
    public class TransactionHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //var moduleName = LocalThreadStorage.GetCurrentBusinessModuleName();

            //PersistenceManager.BeginTransaction(moduleName);

            var methodReturn = getNext()(input, getNext);

            if (methodReturn.Exception != null)
            {
//                PersistenceManager.RollbackTransaction(moduleName);
            }
            else
            {
//                PersistenceManager.CommitTransaction(moduleName);
            }

            return methodReturn;
        }
    }
}