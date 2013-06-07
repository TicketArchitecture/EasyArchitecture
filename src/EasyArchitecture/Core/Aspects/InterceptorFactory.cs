namespace EasyArchitecture.Core.Aspects
{
    public static class InterceptorFactory
    {
        private static  Interceptor _interceptor ;

        public static Interceptor GetInstance()
        {
            return _interceptor ?? (_interceptor = new ContextInterceptor()
                                                       .SetSuccessor(
                                                           new LogInterceptor().SetSuccessor(
                                                               new TransactionInterceptor())));
        }
    }
}