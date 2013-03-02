using System.Text;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Core.Log
{
    internal static class InstanceLogger
    {
        internal static void Log(object intance, string method, params object[] @params)
        {
            var logInstance = InstanceProvider.GetLocalInstance<Logger>();
            if (logInstance == null)
                return;

            if (logInstance._logLevel != LogLevel.Debug)
                return;

            logInstance.Log(logInstance._logLevel, string.Format("\t[{0}] {1} {2}", intance.GetType().Name, method, FormatParameters(@params)), null);
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
                sb.Length= sb.Length-2;

            return sb.ToString();
        }
    }
}
