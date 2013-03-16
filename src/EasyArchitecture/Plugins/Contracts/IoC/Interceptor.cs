namespace EasyArchitecture.Plugins.Contracts.IoC
{
    public abstract class Interceptor
    {
        private Interceptor _successor;

        public Interceptor SetSuccessor(Interceptor successor)
        {
            _successor = successor;
            return this;
        }

        protected object Next(ProxyMethodCall methodCall)
        {
            return _successor != null ? _successor.Invoke(methodCall) : methodCall.Invoke();
        }

        public abstract object Invoke(ProxyMethodCall methodCall);
    }
}