using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace EasyArchitecture.Mechanisms
{
    public class Resource
    {
                private static readonly ResourceManager resource;

                static Resource()
        {
            //string fullTypeFileName = Configurator.GetInstance().GetResourceFullTypeName();

            //try
            //{
            //    string assemblyName = fullTypeFileName.Substring(0, fullTypeFileName.LastIndexOf("."));
            //    resource = new ResourceManager(fullTypeFileName, Assembly.Load(assemblyName));

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("ResourceWrapper - Nao foi possivel instanciar ResourceManager", ex);
            //}
        }

        public static string GetMessage(string resourceCode)
        {
            return resource.GetString(resourceCode);
        }

        public static string GetMessage(string resourceCode, params string[] args)
        {
            string message = resource.GetString(resourceCode);
            if (message != null)
            {
                message = string.Format(message, args);
            }
            return message;
        }

    }
}
