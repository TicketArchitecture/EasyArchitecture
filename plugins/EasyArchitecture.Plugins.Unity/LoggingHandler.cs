using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using EasyArchitecture.Mechanisms;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class LoggingHandler: ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var sw= new Stopwatch();

            LogInvokation(input,sw);

            var msg = getNext()(input, getNext);

            if (msg.Exception != null)
            {
                LogException(input, msg.Exception, sw);
            }
            else
            {
                LogReturn(input, msg, sw);
            }

            return msg;
        }

        private static void LogInvokation(IMethodInvocation input, Stopwatch sw)
        {
            sw.Start();
            var parameters = new StringBuilder();

            for (var counter = 0; counter < input.Inputs.Count; counter++)
            {
                var parameterInfo = input.Inputs.GetParameterInfo(counter);
                parameters.Append(parameterInfo.Name + " (" + Mount(input.Inputs[counter]) + "), ");
            }
            if (input.Inputs.Count>0)
                parameters.Remove(parameters.Length - 2, 2);

            Logger.Message("->[{0}]: {1}", input.MethodBase.Name, parameters).Debug();
        }

        private static void LogReturn(IMethodInvocation input, IMethodReturn message, Stopwatch sw)
        {
            Logger.Message("<-[{0}]: ({1}) [{2}ms]", input.MethodBase.Name, Mount(message.ReturnValue), sw.ElapsedMilliseconds).Debug();
        }

        private static void LogException(IMethodInvocation input, Exception ex, Stopwatch sw)
        {
            Logger.Exception(ex, "x [{0}]: {1} [{2}ms]", input.MethodBase.Name, ex.Message,sw.ElapsedMilliseconds).Debug();
        }

        private static string Mount(object obj)
        {
            var json = new DataContractJsonSerializer(obj.GetType());
            var ms = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
            json.WriteObject(ms, obj);
            writer.Flush();
            return Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length); ;
        }
    }
}