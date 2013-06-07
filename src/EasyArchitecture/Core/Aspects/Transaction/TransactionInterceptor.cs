using System;
using EasyArchitecture.Instances.Persistence;

namespace EasyArchitecture.Core.Aspects.Transaction
{
    internal class TransactionInterceptor : Interceptor
    {
        internal override object Invoke(ProxyMethodCall methodCall)
        {
            object ret;
            
            InstanceProvider.GetInstance<Persistence>().BeginTransaction();
            try
            {
                ret = Next(methodCall);
            }
            catch (Exception)
            {
                InstanceProvider.GetInstance<Persistence>().RollbackTransaction();
                throw;
            }

            InstanceProvider.GetInstance<Persistence>().CommitTransaction();
            return ret;
        }
    }
}