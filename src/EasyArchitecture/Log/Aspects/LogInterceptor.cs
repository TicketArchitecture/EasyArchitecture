using System;
using System.Diagnostics;
using System.Text;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.Runtime.IO;

namespace EasyArchitecture.Log.Aspects
{
    public class LogInterceptor:Interceptor
    {
        public override object Invoke(ProxyMethodCall methodCall)
        {
            object ret;

            var sw = new Stopwatch();

            LogInvokation(methodCall, sw);
            try
            {
                ret = Next(methodCall);
            }
            catch (Exception exception)
            {
                LogException(methodCall, exception, sw);    
                throw;
            }

            LogReturn(methodCall, ret, sw);

            return ret;
        }

        private static void LogInvokation(ProxyMethodCall input, Stopwatch sw)
        {
            sw.Start();
            var parameters = new StringBuilder();

            var counter = 0;
            foreach (var parameterInfo in input.Method.GetParameters())
            {
                parameters.Append(parameterInfo.Name + " (" + SerializationHelper.Mount(input.Parameters[counter++]) + "), ");
            }

            if (counter > 0)
                parameters.Remove(parameters.Length - 2, 2);

            Logger.Message("->[{0}]: {1}", input.Method.Name, parameters).Debug();
        }

        private static void LogReturn(ProxyMethodCall input, object message, Stopwatch sw)
        {
            Logger.Message("<-[{0}]: ({1}) [{2}ms]", input.Method.Name, SerializationHelper.Mount(message), sw.ElapsedMilliseconds).Debug();
        }

        private static void LogException(ProxyMethodCall input, Exception ex, Stopwatch sw)
        {
            Logger.Exception(ex, "x [{0}]: {1} [{2}ms]", input.Method.Name, ex.Message, sw.ElapsedMilliseconds).Debug();
        }
    }
}
