using EasyArchitecture.IoC.Instance;

namespace EasyArchitecture.Persistence.Aspects
{
    public class TransactionInterceptor : Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            object ret = null;
            
            //TODO: call InstanceProvider.GetInstance<IPersi>()
            //ConfigurationSelector.Selector().Persistence.BeginTransaction();
            //try
            //{
            //    ret = Next(methodCall);
            //}
            //catch (Exception)
            //{
            //    ConfigurationSelector.Selector().Persistence.RollbackTransaction();
            //    throw;
            //}

            //ConfigurationSelector.Selector().Persistence.CommitTransaction();
            return null;
        }
    }
}