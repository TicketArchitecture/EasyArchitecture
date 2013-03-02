using System;
using System.Diagnostics;
using EasyArchitecture.Instances.IoC;
using EasyArchitecture.Instances.Log;

namespace EasyArchitecture.Core.Aspects
{
    public class LogInterceptor:Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
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
