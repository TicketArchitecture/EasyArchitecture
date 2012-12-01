using System;
using System.Reflection;

namespace EasyArchitecture.Plugins.Default
{
    public class ObjectMapperPlugin:IObjectMapperPlugin
    {
        public void Configure(Assembly assembly)
        {
            //throw new NotImplementedException();
        }

        public T1 Map<T, T1>(T p0)
        {
            //throw new NotImplementedException();
            return default(T1);
        }

        public T1 Map<T, T1>(T p0, T1 obj1)
        {
            //throw new NotImplementedException();
            return default(T1);
        }
    }
}