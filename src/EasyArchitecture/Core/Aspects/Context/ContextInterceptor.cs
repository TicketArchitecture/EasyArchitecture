namespace EasyArchitecture.Core.Aspects.Context
{
    public class ContextInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            ThreadContext.GetCurrent().Initialize();
            return Next(methodCall);
        }
    }
}