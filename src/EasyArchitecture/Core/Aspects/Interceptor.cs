namespace EasyArchitecture.Core.Aspects
{
    internal abstract class Interceptor
    {
        private Interceptor _successor;

        internal Interceptor SetSuccessor(Interceptor successor)
        {
            _successor = successor;
            return this;
        }

        protected object Next(ProxyMethodCall methodCall)
        {
            return _successor != null ? _successor.Invoke(methodCall) : methodCall.Invoke();
        }

        internal abstract object Invoke(ProxyMethodCall methodCall);
    }
}