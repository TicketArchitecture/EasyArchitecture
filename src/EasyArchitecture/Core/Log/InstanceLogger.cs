using System.Text;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Plugin.Contracts.Log;

namespace EasyArchitecture.Core.Log
{
    internal static class InstanceLogger
    {
        internal static void Log(object intance, string method, params object[] @params)
        {
            var sb = new StringBuilder();

            foreach (var parameterInfo in @params)
            {
                sb.Append(SerializationHelper.Mount(parameterInfo));
                sb.Append(", ");
            }

            if (@params.Length > 0)
                sb.Remove(sb.Length - 2, 2);

            var message = string.Format("\t[{0}] {1} ", intance.GetType().Name, method) + sb;

            var instance = InstanceProvider.GetLocalInstance<Logger>();
            if (instance != null)
                instance.Log(LogLevel.Info, message, null);

        }
    }
}
