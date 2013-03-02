using System;
using System.Reflection;
using System.Text;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Log;

namespace EasyArchitecture.Instances.Log
{
    public static class MethodCallLogger
    {
        internal static void LogInvokation(MethodInfo methodInfo, object[] parametersValue)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();
            if (logInstance._logLevel != EasyArchitecture.Plugin.Contracts.Log.LogLevel.Debug && logInstance._logLevel != EasyArchitecture.Plugin.Contracts.Log.LogLevel.Info)
                return;

            var sb = new StringBuilder();

            var counter = 0;
            foreach (var parameterInfo in methodInfo.GetParameters())
            {
                sb.Append(parameterInfo.Name);
                if (logInstance._logLevel == EasyArchitecture.Plugin.Contracts.Log.LogLevel.Debug)
                {
                    sb.Append(" (");
                    sb.Append(SerializationHelper.Mount(parametersValue[counter++]));
                    sb.Append(")");
                }
                sb.Append(", ");
            }

            if (counter > 0)
                sb.Length = sb.Length - 2;

            if (logInstance._logLevel == EasyArchitecture.Plugin.Contracts.Log.LogLevel.Debug)
            {
                logInstance.LogDebug(string.Format("->[{0}]: {1}", methodInfo.Name, sb), null);
            }
            else
            {
                logInstance.LogInfo(string.Format("->[{0}]", methodInfo.Name), null);
            }
        }

        internal static void LogReturn(MethodInfo methodInfo, object returnValue, long elapsedMilliseconds)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();
            if (logInstance._logLevel != EasyArchitecture.Plugin.Contracts.Log.LogLevel.Debug && logInstance._logLevel != EasyArchitecture.Plugin.Contracts.Log.LogLevel.Info)
                return;

            if (logInstance._logLevel == EasyArchitecture.Plugin.Contracts.Log.LogLevel.Debug)
            {
                logInstance.LogDebug(string.Format("<-[{0}]: ({1}) [{2}ms]", methodInfo.Name, SerializationHelper.Mount(returnValue), elapsedMilliseconds), null);
            }
            else
            {
                logInstance.LogInfo(string.Format("<-[{0}] [{1}ms]", methodInfo.Name, elapsedMilliseconds), null);
            }
        }

        internal static void LogException(MethodInfo methodInfo, Exception ex, long elapsedMilliseconds)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();
            if (logInstance._logLevel != EasyArchitecture.Plugin.Contracts.Log.LogLevel.Debug && logInstance._logLevel != EasyArchitecture.Plugin.Contracts.Log.LogLevel.Info)
                return;

            //HACK: usar delegate?
            if (logInstance._logLevel == EasyArchitecture.Plugin.Contracts.Log.LogLevel.Debug)
                logInstance.LogDebug(string.Format("x [{0}]: {1} [{2}ms]", methodInfo.Name, ex.Message, elapsedMilliseconds), ex);

            if (logInstance._logLevel == EasyArchitecture.Plugin.Contracts.Log.LogLevel.Info)
                logInstance.LogInfo(string.Format("x [{0}]: {1} [{2}ms]", methodInfo.Name, ex.Message, elapsedMilliseconds), ex);
        }
    }
}