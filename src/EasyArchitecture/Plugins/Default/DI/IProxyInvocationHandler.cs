using System;
using System.Reflection;

namespace EasyArchitecture.Plugins.Default.DI
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}