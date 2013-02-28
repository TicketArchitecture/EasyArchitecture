using EasyArchitecture.Instances.IoC;

namespace EasyArchitecture.Core.Aspects
{
    public class ContextInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            LocalThreadStorage.GetCurrentContext().Initialize();
            return Next(methodCall);
        }
    }
}