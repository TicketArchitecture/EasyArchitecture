using System;
using System.Reflection;

namespace EasyArchitecture.Plugins.BultIn.IoC
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}