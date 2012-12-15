using EasyArchitecture.IoC.Instance;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;

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