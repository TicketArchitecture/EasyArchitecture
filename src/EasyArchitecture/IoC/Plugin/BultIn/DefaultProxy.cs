using System;
using System.Reflection;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class DefaultProxy : IProxyInvocationHandler
	{
        readonly Object _obj = null;

        public DefaultProxy( Object obj ) {
            _obj = obj;
        }

        public static Object NewInstance( Object obj ) {
            return ProxyFactory.GetInstance().Create( 
                new DefaultProxy( obj ), obj.GetType() );
        }

        public Object Invoke(Object proxy, System.Reflection.MethodInfo method, Object[] parameters) {

            //return InterceptionHook.GetChain(()=>method.Invoke(_obj, parameters));
            var methodCall = new ProxyMethodCall(_obj, method, parameters);
            //return new InterceptionHook(method, () => method.Invoke(_obj, parameters)).Execute();
            return new InterceptionHook(methodCall ).Execute();

        }
    }

    public class ProxyMethodCall
    {
        private readonly object _o;
        private readonly MethodInfo _method;
        private readonly object[] _parameters;

        public ProxyMethodCall(object o, MethodInfo method, object[] parameters)
        {
            _o = o;
            _method = method;
            _parameters = parameters;
        }
        public object Invoke()
        {
            return _method.Invoke(_o, _parameters);
        }

        public MethodInfo Method
        {
            get { return _method; }
        }
        public object [] Parameters
        {
            get { return _parameters; }
        }
        public Object ObjOrigin
        {
            get { return _o; }
        }
    }
}






