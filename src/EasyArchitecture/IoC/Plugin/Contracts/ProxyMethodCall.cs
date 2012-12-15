using System;
using System.Reflection;

namespace EasyArchitecture.IoC.Plugin.Contracts
{
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