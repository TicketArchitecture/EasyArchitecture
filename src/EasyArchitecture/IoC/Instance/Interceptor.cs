namespace EasyArchitecture.IoC.Instance
{
    public abstract class Interceptor
    {
        private Interceptor _successor;

        public void SetSuccessor(Interceptor successor)
        {
            _successor = successor;
        }

        protected object Next(ProxyMethodCall methodCall)
        {
            return _successor != null ? _successor.Invoke(methodCall) : methodCall.Invoke();
        }

        public abstract object Invoke(ProxyMethodCall methodCall);
    }
}