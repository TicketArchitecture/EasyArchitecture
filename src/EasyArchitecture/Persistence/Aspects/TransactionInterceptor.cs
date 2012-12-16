using System;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Runtime.Aspects;

namespace EasyArchitecture.Persistence.Aspects
{
    public class TransactionInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            object ret;
            
            ConfigurationSelector.Selector().Persistence.BeginTransaction();
            try
            {
                ret = Next(methodCall);
            }
            catch (Exception)
            {
                ConfigurationSelector.Selector().Persistence.RollbackTransaction();
                throw;
            }

            ConfigurationSelector.Selector().Persistence.CommitTransaction();
            return ret;
        }
    }
}