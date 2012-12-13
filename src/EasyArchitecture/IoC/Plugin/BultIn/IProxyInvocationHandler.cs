using System;
using System.Reflection;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}