using System;
using System.Diagnostics;
using System.Text;
using System.Web.Script.Serialization;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Diagnostic
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

            //Log.To(input.MethodBase.DeclaringType).Message("->[{0}]: {1}",input.MethodBase.Name, parameters).Debug();
        }

        private static void LogReturn(IMethodInvocation input, IMethodReturn message, Stopwatch sw)
        {
            //Log.To(input.MethodBase.DeclaringType).Message("<-[{0}]: ({1}) [{2}ms]", input.MethodBase.Name, Mount(message.ReturnValue),sw.ElapsedMilliseconds).Debug();
        }

        private static void LogException(IMethodInvocation input, Exception ex, Stopwatch sw)
        {
            //Log.To(input.MethodBase.DeclaringType).Exception(ex, "x [{0}]: {1} [{2}ms]", input.MethodBase.Name, ex.Message,sw.ElapsedMilliseconds).Debug();
        }

        private static string Mount(object obj)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = 30;
//            Console.WriteLine(serializer.Serialize(p));
            return serializer.Serialize(obj);

            if (obj == null)
                return "null";

            var type = obj.GetType();

            if (type.IsClass)
            {
                return MountClass(obj, type);
            }
            if (type.IsArray)
            {
                return MountArray(obj, type);
            }

            return obj.ToString();
        }

        private static string MountArray(object o, Type type)
        {
            return o.ToString();
        }

        private static string MountClass(object obj, Type type)
        {
            var sb = new StringBuilder();
            var propertiesInfo = type.GetProperties();
            foreach (var propertyInfo in propertiesInfo)
            {
                sb.Append(propertyInfo.Name + "(" + propertyInfo.GetValue(obj, null) + "), ");
            }
            if (propertiesInfo.Length > 0)
                sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }
    }
}