using System;
using System.Diagnostics;

namespace EasyArchitecture.Core.Aspects.Log
{
    public class LogInterceptor:Interceptor
    {
        internal override object Invoke(ProxyMethodCall methodCall)
        {
            object ret;

            var sw = new Stopwatch();
            sw.Start();
            MethodCallLogger.LogInvokation(methodCall.Method, methodCall.Parameters);

            try
            {
                ret = Next(methodCall);
            }
            catch (Exception exception)
            {
                MethodCallLogger.LogException(methodCall.Method, exception, sw.ElapsedMilliseconds);
                throw;
            }

            MethodCallLogger.LogReturn(methodCall.Method, ret, sw.ElapsedMilliseconds);

            return ret;
        }
    }
}
