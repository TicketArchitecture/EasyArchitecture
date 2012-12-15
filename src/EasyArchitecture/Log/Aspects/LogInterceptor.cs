using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using EasyArchitecture.IoC.Instance;
using EasyArchitecture.IoC.Plugin.BultIn;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.Log.Aspects
{
    public class LogInterceptor:Interceptor
    {
        private const string NullValue = "null";

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
                parameters.Append(parameterInfo.Name + " (" + Mount(input.Parameters[counter++]) + "), ");
            }

            //for (var counter = 0; counter < input.Method.GetParameters().Length; counter++)
            //{
            //    var parameterInfo = input.Method.GetParameters().GetParameterInfo(counter);
            //    parameters.Append(parameterInfo.Name + " (" + Mount(input.Inputs[counter]) + "), ");
            //}
            //if (input.Inputs.Count > 0)
            //    parameters.Remove(parameters.Length - 2, 2);
            if (counter > 0)
                parameters.Remove(parameters.Length - 2, 2);

            Logger.Message("->[{0}]: {1}", input.Method.Name, parameters).Debug();
        }

        private static void LogReturn(ProxyMethodCall input, object message, Stopwatch sw)
        {
            Logger.Message("<-[{0}]: ({1}) [{2}ms]", input.Method.Name, Mount(message), sw.ElapsedMilliseconds).Debug();
        }

        private static void LogException(ProxyMethodCall input, Exception ex, Stopwatch sw)
        {
            Logger.Exception(ex, "x [{0}]: {1} [{2}ms]", input.Method.Name, ex.Message, sw.ElapsedMilliseconds).Debug();
        }

        private static string Mount(object obj)
        {
            if (obj == null)
                return NullValue;

            var json = new DataContractJsonSerializer(obj.GetType());
            var ms = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
            json.WriteObject(ms, obj);
            writer.Flush();
            return Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length); 
        }
    }
}
