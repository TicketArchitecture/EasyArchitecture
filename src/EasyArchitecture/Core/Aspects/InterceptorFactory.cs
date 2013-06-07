using EasyArchitecture.Core.Aspects.Context;
using EasyArchitecture.Core.Aspects.Log;
using EasyArchitecture.Core.Aspects.Transaction;

namespace EasyArchitecture.Core.Aspects
{
    internal static class InterceptorFactory
    {
        private static  Interceptor _interceptor ;

        internal static Interceptor GetInstance()
        {
            return _interceptor ?? (_interceptor = new ContextInterceptor()
                                                       .SetSuccessor(
                                                           new LogInterceptor().SetSuccessor(
                                                               new TransactionInterceptor())));
        }
    }
}