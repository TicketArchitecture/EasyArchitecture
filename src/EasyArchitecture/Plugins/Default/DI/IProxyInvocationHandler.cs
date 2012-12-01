using System;
using System.Reflection;

namespace EasyArchitecture.DI
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}