using System;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.Runtime.Aspects;

namespace EasyArchitecture.Persistence.Aspects
{
    public class TransactionInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            object ret;
            
            ConfigurationSelector.SelectorByThread().Persistence.BeginTransaction();
            try
            {
                ret = Next(methodCall);
            }
            catch (Exception)
            {
                ConfigurationSelector.SelectorByThread().Persistence.RollbackTransaction();
                throw;
            }

            ConfigurationSelector.SelectorByThread().Persistence.CommitTransaction();
            return ret;
        }
    }
}