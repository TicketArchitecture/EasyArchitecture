using System.Text;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Runtime.IO;

namespace EasyArchitecture.Runtime.Log
{
    internal static class InstanceLogger
    {
        internal static void Log(object intance, string method, params object[] @params)
        {
            var type = intance.GetType();


            var parameters = new StringBuilder();

            var counter = 0;
            foreach (var parameterInfo in @params)
            {
                parameters.Append(SerializationHelper.Mount(@params[counter++]) + ", ");
            }

            if (counter > 0)
                parameters.Remove(parameters.Length - 2, 2);

            var message = string.Format("\t[{0}] {1} ", type.Name, method) + parameters;
            
            var instance = InstanceProvider.GetLocalInstance<EasyArchitecture.Log.Instance.Logger>();
            if (instance != null)
                instance.Log(LogLevel.Debug, message, null);

        }
    }
}
