using System;
using EasyArchitecture.Instances.IoC;
using EasyArchitecture.Instances.Persistence;

namespace EasyArchitecture.Core.Aspects
{
    public class TransactionInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            object ret = null;
            
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