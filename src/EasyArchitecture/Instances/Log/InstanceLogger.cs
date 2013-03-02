using System.Text;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Log;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Instances.Log
{
    internal static class InstanceLogger
    {
        internal static void Log(object intance, string method, params object[] @params)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();

            if (logInstance._logLevel != LogLevel.Debug)
                return;

            logInstance.LogDebug(string.Format("\t[{0}] {1} {2}", intance.GetType().Name, method, FormatParameters(@params)), null);
        }

        private static string FormatParameters(object[] @params)
        {
            var sb = new StringBuilder();

            foreach (var parameterInfo in @params)
            {
                sb.Append(SerializationHelper.Mount(parameterInfo));
                sb.Append(", ");
            }

            if (@params.Length > 0)
                sb.Length = sb.Length - 2;

            return sb.ToString();
        }
    }
}
