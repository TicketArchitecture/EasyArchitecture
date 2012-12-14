using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.Log.Aspects;
using EasyArchitecture.Persistence.Aspects;
using EasyArchitecture.Runtime.Aspects;

namespace EasyArchitecture.IoC.Plugin.Contracts
{
    public class InterceptionHook
    {
        private readonly ProxyMethodCall _methodCall;
        private readonly ContextInterceptor _contextInterceptor;

        public InterceptionHook(ProxyMethodCall methodCall)
        {
            _methodCall = methodCall;
            var logInterceptor = new LogInterceptor();
            var transactionInterceptor = new TransactionInterceptor();
            _contextInterceptor = new ContextInterceptor();

            //sequence
            _contextInterceptor.SetSuccessor(logInterceptor);
            logInterceptor.SetSuccessor(transactionInterceptor);
            
        }

        public object Execute()
        {
            return _contextInterceptor.Invoke(_methodCall);
        }
    }
}
