using System;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Persistence.Aspects
{
    public class TransactionInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            object ret = null;
            
            InstanceProvider.GetInstance<Instance.Persistence>().BeginTransaction();
            try
            {
                ret = Next(methodCall);
            }
            catch (Exception)
            {
                InstanceProvider.GetInstance<Instance.Persistence>().RollbackTransaction();
                throw;
            }

            InstanceProvider.GetInstance<Instance.Persistence>().CommitTransaction();
            return ret;
        }
    }
}