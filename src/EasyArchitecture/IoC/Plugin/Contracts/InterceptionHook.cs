using System.Reflection;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.Log.Aspects;
using EasyArchitecture.Persistence.Aspects;
using EasyArchitecture.Runtime.Aspects;

namespace EasyArchitecture.IoC.Plugin.Contracts
{
    public class InterceptionHook
    {
        private readonly ProxyMethodCall _methodCall;
        private readonly Interceptor _contextInterceptor;

        public InterceptionHook(object o, MethodInfo method, object[] parameters)
        {
            _methodCall = new ProxyMethodCall(o, method, parameters);
            _contextInterceptor = new ContextInterceptor().SetSuccessor(new LogInterceptor().SetSuccessor(new TransactionInterceptor()));
        }

        public object Execute()
        {
            return _contextInterceptor.Invoke(_methodCall);
        }
    }
}
