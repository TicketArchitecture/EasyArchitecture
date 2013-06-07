using System;
using EasyArchitecture.Instances.Persistence;
using EasyArchitecture.Plugins.Contracts.IoC;

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