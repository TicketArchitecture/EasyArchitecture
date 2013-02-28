using System.Reflection;
using EasyArchitecture.Core.Aspects;
using EasyArchitecture.Instances.IoC;

namespace EasyArchitecture.Plugin.Contracts.IoC
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
