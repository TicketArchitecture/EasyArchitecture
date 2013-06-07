namespace EasyArchitecture.Core.Aspects.Context
{
    internal class ContextInterceptor : Interceptor
    {
        internal override object Invoke(ProxyMethodCall methodCall)
        {
            ThreadContext.GetCurrent().Initialize();
            return Next(methodCall);
        }
    }
}