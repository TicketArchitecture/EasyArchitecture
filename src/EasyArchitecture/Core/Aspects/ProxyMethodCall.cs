using System;
using System.Reflection;

namespace EasyArchitecture.Core.Aspects
{
    internal class ProxyMethodCall
    {
        private readonly object _o;
        private readonly MethodInfo _method;
        private readonly object[] _parameters;

        internal ProxyMethodCall(object o, MethodInfo method, object[] parameters)
        {
            _o = o;
            _method = method;
            _parameters = parameters;
        }

        internal object Invoke()
        {
            object ret;
            try
            {
                ret = _method.Invoke(_o, _parameters);
            }
            catch (TargetInvocationException targetInvocationException)
            {
                throw targetInvocationException.InnerException;
            }
            return ret;
        }

        internal MethodInfo Method
        {
            get { return _method; }
        }

        internal object [] Parameters
        {
            get { return _parameters; }
        }

        internal Object ObjOrigin
        {
            get { return _o; }
        }
    }
}