using System.Reflection;
using EasyArchitecture.Log.Aspects;
using EasyArchitecture.Persistence.Aspects;
using EasyArchitecture.Runtime.Aspects;

namespace EasyArchitecture.IoC.Plugin.Contracts
{
    public class InterceptionHook
    {
        private readonly ProxyMethodCall _methodCall;
        private readonly ContextInterceptor _contextInterceptor;

        public InterceptionHook(object o, MethodInfo method, object[] parameters)
        {
            _methodCall = new ProxyMethodCall(o, method, parameters);

            //TODO: retirar essa sequencia hardcoded daqui
            //TODO: chamar a configuracao??? solicitando a lista de interceptors?
            var logInterceptor = new LogInterceptor();
            var transactionInterceptor = new TransactionInterceptor();
            _contextInterceptor = new ContextInterceptor();

            //get rootInterceptor from configuration
            

            //sequence
            _contextInterceptor.SetSuccessor(logInterceptor);
            logInterceptor.SetSuccessor(transactionInterceptor);
        }

        public object Execute()
        {
            //if rootInterceptor == null -> call _methodCall.Invoke;

            //else _rootInterceptor.Invoke(_methodCall);

            return _contextInterceptor.Invoke(_methodCall);
        }
    }
}
