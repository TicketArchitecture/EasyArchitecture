using System;
using System.Reflection;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}