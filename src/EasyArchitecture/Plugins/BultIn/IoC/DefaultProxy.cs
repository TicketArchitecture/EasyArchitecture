using System;
using EasyArchitecture.Core.Aspects;

namespace EasyArchitecture.Plugins.BultIn.IoC
{
    internal class DefaultProxy : IProxyInvocationHandler
	{
        readonly Object _obj;

        public DefaultProxy( Object obj ) {
            _obj = obj;
        }

        public Object Invoke(Object proxy, System.Reflection.MethodInfo method, Object[] parameters) {
            return InterceptorFactory.GetInstance().Invoke(new ProxyMethodCall(_obj, method, parameters));
        }
    }
}






