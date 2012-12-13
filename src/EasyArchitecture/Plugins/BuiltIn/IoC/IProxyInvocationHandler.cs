using System;
using System.Reflection;

namespace EasyArchitecture.Plugins.BuiltIn.IoC
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}