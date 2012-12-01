using EasyArchitecture.Mechanisms;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class TransactionHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            PersistenceManager.BeginTransaction();
            
            var methodReturn = getNext()(input, getNext);

            if (methodReturn.Exception != null)
            {
                PersistenceManager.RollbackTransaction();
            }
            else
            {
                PersistenceManager.CommitTransaction();
            }

            return methodReturn;
        }
    }
}