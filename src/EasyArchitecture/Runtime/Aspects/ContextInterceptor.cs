using EasyArchitecture.IoC.Instance;

namespace EasyArchitecture.Runtime.Aspects
{
    public class ContextInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            LocalThreadStorage.SetCurrentModuleName(methodCall.Method.DeclaringType);
            return Next(methodCall);
        }
    }
}